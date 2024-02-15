using System;
using System.IO;

namespace FindString
{
    public class Rename
    {
        public static void RenameFiles()
        {
            try
            {
                Console.WriteLine("========== Rename Files ==========");

                Console.Write("Insert path: ");
                string path = "";

                while (true)
                {
                    path = Console.ReadLine();

                    if (!Directory.Exists(path))
                        Console.WriteLine("Path does not exist or it was written wrongly. Insert path.");
                    else
                        break;
                }

                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] infos = d.GetFiles();

                if (infos.Length == 0)
                {
                    Console.WriteLine("No files found.");
                    RenameFiles();
                }

                bool backup = Helper.AskBool("Do you want to backup folder? ");

                if (backup)
                {
                    Console.Write("Insert destination path: ");
                    string destinationPath = Console.ReadLine();

                    Helper.CopyDirectory(path, destinationPath);
                }

                Console.WriteLine("Enter the old value of the string: ");
                string oldValue = Console.ReadLine();

                Console.WriteLine("Enter the new value of the string: ");
                string newValue = Console.ReadLine();

                var counterFiles = 0;

                foreach (FileInfo f in infos)
                {
                    File.Move(f.FullName, f.FullName.Replace(oldValue, newValue));
                    counterFiles++;
                }

                Console.WriteLine($"Files renamed: {counterFiles}");

                bool repeatOperation = Helper.AskBool("Do you want to repeat the operation with other files? ");

                if (repeatOperation)
                    RenameFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }
        }
    }
}