using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    public class DriveManager
    {
        public static List<string> DiscoverDrives()
        {
            List<string> Drives = new List<string>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                Drives.Add(drive.Name);
            }

            return Drives;
        }

        public static void InitDrives()
        {
            List<string> drives = DiscoverDrives();
            if (drives.Count == 1)
            {
                Settings.disk1 = drives[0];
                Settings.disk2 = drives[0];
            }
            else
            {
                Settings.disk1 = drives[0];
                Settings.disk2 = drives[1];
            }
        }
    }
}
