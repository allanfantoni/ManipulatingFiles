using System;
using System.IO;
using System.Linq;

namespace FindString
{
    public class Remove
    {
        public static void RemoveLines()
        {
            try
            {
                Console.WriteLine("========== Removing Lines ==========");

                string path = Helper.InsertPath();

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
                    Console.Write("Insert destination path: ");
                    string destinationPath = Console.ReadLine();

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

        public static void RemoveLinesAtBeginning(string path)
        {
            Console.WriteLine("========== Remove Lines at the Beginning ==========");

            Console.Write("Enter how many lines do you want to remove: ");
            int linesToRemove = int.Parse(Console.ReadLine());

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                //File.WriteAllLines(file, lines.Skip(linesToRemove).ToArray());
                Helper.WriteAllLinesBetter(file, lines.Skip(linesToRemove).ToArray());
            }

            Console.WriteLine($"Files modified: {files.Count()}");
        }

        public static void RemoveLinesAtEnd(string path)
        {
            Console.WriteLine("========== Remove Lines at the End ==========");

            Console.Write("Enter how many lines do you want to remove: ");
            int linesToRemove = int.Parse(Console.ReadLine());

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                Helper.WriteAllLinesBetter(file, lines.Take(lines.Length - linesToRemove).ToArray());
            }

            Console.WriteLine($"Files modified: {files.Count()}");
        }
    }
}