using System;
using System.IO;

namespace FileManager
{
    public class Item
    {
        public string name;
        public string path;
        public string size;
        public string mTime;
        public bool isDirectory;

        public Item(string name, bool isDirectory, string path)
        {
            this.isDirectory = isDirectory;
            this.path = path + name;

            if (this.isDirectory)
            {
                this.name = @"\" + name;
                this.path += @"\";
                this.size = "";
            }
            else
            {
                this.name = name;
                this.size = GetFileSize();
            }
            this.mTime = GetMTime();
        }

        // Načte velikost souboru
        public string GetFileSize()
        {
            if (this.isDirectory)
            {
                //TODO --spočítat velikost všech souborů v zanořených adresářích
                return "";
            }
            double byteSize = 0;
            FileInfo info = new FileInfo(this.path);
            byteSize = info.Length;
            double kbSize = byteSize / 1024;
            double fileSize = Math.Round(kbSize, 0);
            return fileSize.ToString();

        }

        // Načte poslední datum úpravy
        public string GetMTime()
        {
            FileInfo file = new FileInfo(this.path);
            return file.LastWriteTime.ToString("MMM dd HH:mm");
        }

        public string GetFormattedName()
        {
            if (this.name.Length <= Settings.MaxNameLenght)
            {
                return this.name;
            }
            return this.name.Substring(0, Settings.MaxNameLenght).Trim() + "...";
        }
    }
}
