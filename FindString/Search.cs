using System;
using System.IO;

namespace FindString
{
    public class Search
    {
        public static void SearchForString()
        {
            try
            {
                Console.WriteLine("========== Search For String ==========");

                Console.Write("Insert path: ");
                string path = Console.ReadLine();

                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException("Path does not exist or it was written wrongly.");

                Console.Write("Do you want to backup folder? ");

                Console.Write("Start character position: ");
                int position = int.Parse(Console.ReadLine());

                Console.Write("Length: ");
                int length = int.Parse(Console.ReadLine());

                Console.Write("Char/string to search: ");
                string text = Console.ReadLine();

                var counterFiles = 0;

                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        var counterLines = 0;
                        var line = "";

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