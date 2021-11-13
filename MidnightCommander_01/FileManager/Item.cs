using System;

namespace FileManager
{
    public class Item
    {
        public string name;
        public string path;
        public bool isDirectory;

        public Item(string name, bool isDirectory, string path)
        {
            this.isDirectory = isDirectory;
            this.path = path + name;

            if (this.isDirectory)
            {
                this.name = @"\" + name;
                this.path += @"\";
            }
            else
            {
                this.name = name;
            }
        }

        public void DrawLine()
        {
            Console.Write(this.name.PadRight(Settings.panelRowWidth, ' '));
        }
    }
}
