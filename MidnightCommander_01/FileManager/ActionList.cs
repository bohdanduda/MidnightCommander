using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class ActionList
    {
        private List<string> actions = new List<string>();

        public ActionList()
        {
            actions.Add("Help");
            actions.Add("Menu");
            actions.Add("View");
            actions.Add("Edit");
            actions.Add("Copy");
            actions.Add("RenMov");
            actions.Add("MkDir");
            actions.Add("Delete");
            actions.Add("Change drive");
            actions.Add("Quit");
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 29);
            int hotkeyNumber = 1;
            foreach (string action in actions)
            {
                Console.Write($" {hotkeyNumber}");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(action.PadRight(8, ' '));
                Console.ResetColor();
                hotkeyNumber++;
            }
        }

    }
}
