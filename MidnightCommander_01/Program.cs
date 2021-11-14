using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DriveManager.InitDrives();

            FileManager fileManager = new FileManager();
            fileManager.Draw();

            while (true)
            {
                Settings.forceClearMessage = true;
                fileManager.HandleKey();
                if (Settings.forceReload)
                {
                    fileManager.Reload();
                    Settings.forceReload = false;
                }
                if (Settings.forceRedraw)
                {
                    fileManager.Draw();
                    Settings.forceRedraw = false;
                }
                if (Settings.forceClearMessage)
                {
                    FileManager.ClearMessage();
                }
                if (Settings.forceExit)
                {
                    break;
                }
            }
        }
    }
}