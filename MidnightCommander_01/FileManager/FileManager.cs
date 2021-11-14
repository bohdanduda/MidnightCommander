using System;
using System.Collections.Generic;

namespace FileManager
{
    public class FileManager
    {
        public Panel LeftPanel;
        public Panel RightPanel;
        public ActionList ActionList = new ActionList();

        

        public FileManager()
        {
            this.LeftPanel = new Panel(Settings.disk1, 0);
            this.RightPanel = new Panel(Settings.disk2, Settings.panelRowWidth + 2);
            this.LeftPanel.isSelected = true;
            this.LeftPanel.Load();
            this.RightPanel.Load();
        }

        public void Reload()
        {
            this.LeftPanel.Load();
            this.RightPanel.Load();
        }

        public void Draw()
        {
            this.LeftPanel.Draw();
            this.RightPanel.Draw();
            this.ActionList.Draw();

        }
        
        public void HandleKey()
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey();

            switch (keyinfo.Key)
            {
                case ConsoleKey.Tab:
                    TogglePanel();
                    break;
                case ConsoleKey.UpArrow:
                    GetSelectedPanel().SelectUp();
                    break;
                case ConsoleKey.DownArrow:
                    GetSelectedPanel().SelectDown();
                    break;
                case ConsoleKey.Enter:
                    GetSelectedPanel().Enter();
                    break;
                case ConsoleKey.F6:
                    GetSelectedPanel().RmDir();
                    break;
                case ConsoleKey.F7:
                    GetSelectedPanel().MkDir();
                    break;
                case ConsoleKey.F9:
                    GetSelectedPanel().SelectDrive();
                    break;
                case ConsoleKey.F10:
                    Settings.forceExit = true;
                    break;
                default:
                    break;
            }
        }
        public void TogglePanel()
        {
            LeftPanel.isSelected = !LeftPanel.isSelected;
            RightPanel.isSelected = !RightPanel.isSelected;
            Settings.forceRedraw = true;
        }

        public static void WriteMessage(string input)
        {
            ClearMessage();
            Console.ResetColor();
            Console.SetCursorPosition(1, Settings.itemsToDraw + 1);
            Console.Write(input);
            Settings.forceClearMessage = false;
        }

        public static void ClearMessage()
        {
            for (int i = 0; i < (Console.BufferWidth); i++)
            {
                Console.SetCursorPosition(i, Settings.itemsToDraw + 1);
                Console.Write(' ');
            }
        }

        public Panel GetSelectedPanel()
        {
            if (this.LeftPanel.isSelected)
            {
                return this.LeftPanel;
            }

            return this.RightPanel;
        }
    }
}
