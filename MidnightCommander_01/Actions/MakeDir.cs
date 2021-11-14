using System;
using System.IO;

namespace Actions
{
    public class MakeDir : PopUp
    {
        public MakeDir()
        {
            this.width = 32;
            this.height = 8;
            this.offsetLeft = 44;
            this.offsetTop = 10;
        }

        public void MkDir(string path)
        {
            this.DrawFrame();
            int left = this.offsetLeft + 2;
            int top = this.offsetTop + 2;

            Console.SetCursorPosition(left, top);
            Console.Write("Enter new directory name: ");
            
            top++;
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = true;
            string newName = Console.ReadLine();
            Console.CursorVisible = false;

            top++;
            Console.SetCursorPosition(left, top);
            string newDir = path + newName;

            try
            {
                if (Directory.Exists(newDir))
                {
                    Console.Write("That directory already exists.");
                    top++;
                    Console.SetCursorPosition(left, top);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(newDir);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            finally { }
        }
    }
}
