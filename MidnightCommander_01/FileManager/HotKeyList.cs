using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class HotKeyList
    {
        private List<string> hotkeys = new List<string>();

        public HotKeyList()
        {
            hotkeys.Add("Help");
            hotkeys.Add("Menu");
            hotkeys.Add("View");
            hotkeys.Add("Edit");
            hotkeys.Add("Copy");
            hotkeys.Add("RenMov");
            hotkeys.Add("MkDir");
            hotkeys.Add("Delete");
            hotkeys.Add("Change drive");
            hotkeys.Add("Quit");
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 29);
            int hotkeyNumber = 1;
            foreach (string hotkey in hotkeys)
            {
                Console.Write($" {hotkeyNumber}");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(hotkey.PadRight(8, ' '));
                Console.ResetColor();
                hotkeyNumber++;
            }
        }

    }
}
