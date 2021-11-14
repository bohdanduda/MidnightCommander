using FileManager;
using System;
using System.IO;

namespace Actions
{
    public class RemoveDir : PopUp
    {
        public RemoveDir()
        {
            this.width = 32;
            this.height = 8;
            this.offsetLeft = 44;
            this.offsetTop = 10;
        }

        public void RmDir(Item item)
        {
            this.DrawFrame();
            int left = this.offsetLeft + 2;
            int top = this.offsetTop + 2;

            Console.SetCursorPosition(left, top);
            if (item.isDirectory)
            {
                Console.Write("Directory to be deleted: ");
            }
            else
            {
                Console.Write("File to be deleted: ");
            }
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write(item.path);
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("Are you sure? (Y/N)");
            Console.CursorVisible = true;
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Console.CursorVisible = false;
            if (keyInfo.Key == ConsoleKey.Y)
            {
                try
                {
                    Directory.Delete(item.path);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
            }
        }
    }
}
