using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace FileManager
{
    public class Panel
    {
        public List<Item> itemList = new List<Item>();
        public int offsetLeft;
        public int itemsDrawn = 0;
        public bool isSelected = false;
        public Item itemSelected;
        public int selection;
        public int scroll = 0;
        public string path;
        public string diskName;


        public Panel(string diskName, int offsetLeft)
        {
            this.offsetLeft = offsetLeft;
            this.diskName = diskName;
            this.path = diskName;
        }

        // hlavní funkce na načtení a vypsání souborů a složek
        public void Load()
        {
            this.itemList.Clear();

            // cestu zpět přidat pouze pokud nejsme v kořenové složce disku
            if (this.path != this.diskName)
            {
                this.itemList.Add(new Item("..", true, this.path));
                SetParentDirectoryPath();
            }
            GetDirectories();
            GetFiles();
            this.selection = 0;
            this.scroll = 0;
            this.itemSelected = this.itemList[this.selection];
            Draw();
        }

        // přidá "\.." a přidá cestu k minulému adresáři
        public void SetParentDirectoryPath()
        {
            itemList[0].path = path.Substring(0, path.Length - path.Split('\\')[path.Split('\\').Length - 2].Length - 1);
        }

        // načtení adresářů
        public void GetDirectories()
        {
            foreach (string directoryName in Directory.GetDirectories(this.path))
            {
                itemList.Add(new Item(directoryName.Substring(this.path.Length), true, this.path));
            }
        }

        // načtení souborů 
        public void GetFiles()
        {
            foreach (string fileName in Directory.GetFiles(this.path))
            {
                itemList.Add(new Item(fileName.Substring(this.path.Length), false, this.path));
            }
        }

        // vypsání tabulky a souborů
        public void Draw()
        {
            DrawTop();
            DrawBody();
            DrawBottom();
            Console.ResetColor();
        }

        // vypsání řádku okraje
        public void DrawBorderLine(char left, char middle, char right)
        {
            Console.Write(left);
            for (int i = 0; i < Settings.panelRowWidth; i++)
            {
                Console.Write(middle);
            }
            Console.Write(right);
        }

        // horní okraj tabulky
        public void DrawTop()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(this.offsetLeft, 0);
            DrawBorderLine('┌', '─', '┐');

            // vypíše přes okraj vybraný disk a adresář
            Console.SetCursorPosition(this.offsetLeft + 4, 0);
            int startIndex = Settings.panelRowWidth - 6;
            if (this.isSelected) Console.BackgroundColor = ConsoleColor.Blue;
            if (this.path.Length > Settings.panelRowWidth - 6)
            {
                Console.Write("..." + this.path.Substring(this.path.Length - (Settings.panelRowWidth - 6), Settings.panelRowWidth - 6));
            }
            else
            {
                Console.Write(this.path);
            }
            Console.ResetColor();
        }

        // dolní okraj tabulky
        public void DrawBottom()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(this.offsetLeft, this.itemsDrawn + 1);
            DrawBorderLine('└', '─', '┘');
            Console.WriteLine();
            this.itemsDrawn = 0;
            Console.ResetColor();
        }

        // vypíše položky a když dorazí na konec seznamu, tak vypíše prázdné řádky
        public void DrawBody()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(offsetLeft, 1);
            DrawHeadingLine();

            int height = 2;
            for (int i = scroll; i < Settings.itemsToDraw + scroll - 1; i++)
            {
                Console.SetCursorPosition(offsetLeft, height);
                height++;
                if (i<itemList.Count)
                {
                    if (i == selection && this.isSelected)
                    {
                        DrawActiveItemLine(itemList[i]);
                    }
                    else
                    {
                        DrawItemLine(itemList[i]);
                    }
                }
                else
                {
                    DrawEmptyLine();
                }
                itemsDrawn++;
            }
            Console.ResetColor();
        }

        public void DrawHeadingLine()
        {
            DrawLine("Name".PadLeft(18, ' '), "Size".PadRight(7, ' '), "MTime".PadLeft(8, ' '), ConsoleColor.Yellow, ConsoleColor.DarkBlue);
        }
        public void DrawItemLine(Item item)
        {
            DrawLine(item.GetFormattedName(), item.GetFileSize(), item.GetMTime(), ConsoleColor.White, ConsoleColor.DarkBlue);
        }
        public void DrawActiveItemLine(Item item)
        {
            DrawLine(item.GetFormattedName(), item.GetFileSize(), item.GetMTime(), ConsoleColor.White, ConsoleColor.Blue);
        }
        public void DrawEmptyLine()
        {
            DrawLine("", "", "", ConsoleColor.White, ConsoleColor.DarkBlue);
        }

        public void DrawLine(string text1, string text2, string text3, ConsoleColor textColor, ConsoleColor bgrColor)
        {

            Console.Write("│");
            Console.BackgroundColor = bgrColor;
            Console.ForegroundColor = textColor;
            Console.Write(text1.PadRight(Settings.NameColumnWidth, ' '));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("│");
            Console.ForegroundColor = textColor;
            Console.Write(text2.PadLeft(Settings.SizeColumnWidth, ' '));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("│");
            Console.ForegroundColor = textColor;
            Console.Write(text3.PadRight(Settings.MTimeColumnWidth, ' '));
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("│");
        }


        // vybere položku nahoře
        public void SelectUp()
        {
            if (this.selection > 0)
            {
                this.selection = this.selection - 1;
            }
            if (this.scroll == this.selection)
            {
                ScrollUp();
            }
            this.itemSelected = this.itemList[this.selection];
            Draw();
        }

        // vybere položku dole
        public void SelectDown()
        {
            if (this.selection < this.itemList.Count - 1)
            {
                this.selection++;
                DrawBottom();
            }
            if (this.scroll == this.selection + 2 - Settings.itemsToDraw)
            {
                ScrollDown();
            }
            itemSelected = itemList[selection];
            Draw();
        }

        // když je výběr u začátku itemsToDraw, posune o 5 položek nahoru
        public void ScrollUp()
        {
            if (this.scroll - 5 >= 0)
            {
                this.scroll = this.scroll - 5;
            }
        }

        // když je výběr u konce itemsToDraw, posune o 5 položek dolů
        public void ScrollDown()
        {
            if (this.scroll + Settings.itemsToDraw < this.itemList.Count + 1)
            {
                this.scroll = this.scroll + 5;
            }
        }

        // přejde do vybraného adresáře
        public void Enter()
        {
            if (itemSelected.isDirectory)
            {
                // záloha aktuálních hodnot
                string currentPath = this.path;
                List<Item> currentItemList = new List<Item>(this.itemList);

                try
                {
                    this.path = itemSelected.path;
                    this.Load();
                    this.selection = 0;
                    this.scroll = 0;
                }
                catch
                {
                    // při chybě vrátit hodnoty zpátky ze zálohy
                    this.path = currentPath;
                    this.itemList = currentItemList;
                    FileManager.WriteMessage("Cannot change directory");
                }
            }
        }
    }
}
