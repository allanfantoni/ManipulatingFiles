using System;
using System.IO;

namespace ManipulatingFiles
{
    public class Search
    {
        public static void SearchForString()
        {
            try
            {
                Console.WriteLine("========== Searching For String ==========");

                string path = Helper.InsertPath();

                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] infos = d.GetFiles();

                if (infos.Length == 0)
                {
                    Console.WriteLine("No files found.");
                    SearchForString();
                }
                
                int position = Helper.AskInt("Start character position: ");

                int length = Helper.AskInt("Length: ");

                Console.Write("Char/string to search: ");
                string text = Console.ReadLine();

                int counterFiles = 0;

                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        int counterLines = 0;
                        string line = "";

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Substring(position - 1, length) == text)
                            {
                                counterLines++;
                                Console.WriteLine($"{counterLines} - File: {file} - Line: {line}");
                            }
                        }

                        counterFiles++;
                        sr.Close();
                    }
                }

                Console.WriteLine($"Files read: {counterFiles}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }
        }
    }
}