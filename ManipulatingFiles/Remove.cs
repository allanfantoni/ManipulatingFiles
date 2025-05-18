using System;
using System.IO;
using System.Linq;

namespace ManipulatingFiles
{
    internal class Remove
    {
        internal static void RemoveLines()
        {
            try
            {
                Console.WriteLine("========== Removing Lines ==========");

                string path = Helper.EnterPath("Enter path of the file(s): ");

                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] infos = d.GetFiles();

                if (infos.Length == 0)
                {
                    Console.WriteLine("No files found.");
                    RemoveLines();
                }

                bool backup = Helper.AskBool("Do you want to backup folder? ");

                if (backup)
                {
                    string destinationPath = Helper.EnterPath("Enter destination path: ");

                    Helper.CopyDirectory(path, destinationPath);
                }

                bool beginning = Helper.AskBool("Do you want to remove lines at the beginning of the file? ");

                if (beginning)
                    RemoveLinesAtBeginning(path);
                else
                    RemoveLinesAtEnd(path);

                bool repeatOperation = Helper.AskBool("Do you want to repeat the operation with other files? ");

                if (repeatOperation)
                    RemoveLines();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }
        }

        private static void RemoveLinesAtBeginning(string path)
        {
            Console.WriteLine("========== Remove Lines at the Beginning ==========");

            int linesToRemove = Helper.AskInt("Enter how many lines do you want to remove: ");

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                Helper.WriteAllLines(file, lines.Skip(linesToRemove).ToArray());
            }

            Console.WriteLine($"Files modified: {files.Count()}");
        }

        private static void RemoveLinesAtEnd(string path)
        {
            Console.WriteLine("========== Remove Lines at the End ==========");

            int linesToRemove = Helper.AskInt("Enter how many lines do you want to remove: ");

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                Helper.WriteAllLines(file, lines.Take(lines.Length - linesToRemove).ToArray());
            }

            Console.WriteLine($"Files modified: {files.Count()}");
        }
    }
}