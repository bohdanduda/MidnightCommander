using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    public class DriveSelector : PopUp
    {
        public string SelectDrive()
        {
            List<string> drives = DriveManager.DiscoverDrives();
            int selected = 0;
            while (true)
            {
                this.DrawFrame();
                int left = this.offsetLeft + 2;
                int top = this.offsetTop + 2;

                for (int i = 0; i < drives.Count; i++)
                {
                    Console.SetCursorPosition(left, top);
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine(drives[i]);
                    Console.BackgroundColor = this.bgrColor;
                    top++;
                }

                ConsoleKeyInfo keyinfo = Console.ReadKey();

                switch (keyinfo.Key)
                {

                    case ConsoleKey.UpArrow:
                        if (selected > 0)
                        {
                            selected--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selected < drives.Count - 1)
                        {
                            selected++;
                        }
                        break;
                    case ConsoleKey.Enter:

                        return drives[selected];
                        break;
                    default:
                        break;
                }

            }
        }



    }
}
