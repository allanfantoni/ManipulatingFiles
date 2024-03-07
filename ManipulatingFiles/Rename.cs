using System;
using System.IO;

namespace ManipulatingFiles
{
    public class Rename
    {
        public static void RenameFiles()
        {
            try
            {
                Console.WriteLine("========== Renaming Files ==========");

                string path = Helper.EnterPath("Enter path of the file(s): ");

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
                    string destinationPath = Helper.EnterPath("Enter destination path: ");

                    Helper.CopyDirectory(path, destinationPath);
                }

                Console.Write("Enter the old value of the string: ");
                string oldValue = Console.ReadLine();

                Console.Write("Enter the new value of the string: ");
                string newValue = Console.ReadLine();

                int counterFiles = 0;

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