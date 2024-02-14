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
                string path = Console.ReadLine();

                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException("Path does not exist or it was written wrongly.");

                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] infos = d.GetFiles();

                if (infos.Length == 0)
                {
                    Console.WriteLine("No files found.");
                    Console.WriteLine("Press any key to close the window.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                bool answer = Helper.AskBool("Do you want to backup folder?");

                if (answer)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }
        }
    }
}