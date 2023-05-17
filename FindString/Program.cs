using System;
using System.IO;

namespace FindString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert path: ");
            var path = Console.ReadLine();

            if (Directory.Exists(path))
                SearchForString(path);
            else
                Console.WriteLine("Path does not exist or it was written wrongly.");

            Console.ReadKey();
        }

        public static void SearchForString(string path)
        {
            try
            {
                Console.Write("Start character position: ");
                var position = int.Parse(Console.ReadLine());

                Console.Write("Length: ");
                var length = int.Parse(Console.ReadLine());

                Console.Write("Char/string to search: ");
                var text = Console.ReadLine();

                var counterFiles = 0;

                string[] files = Directory.GetFiles(path);

                foreach (var file in files)
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
                                Console.WriteLine(counterLines + " - File: " + file + " - Line: " + line);
                            }
                        }

                        counterFiles++;
                        sr.Close();
                    }
                }

                Console.WriteLine("Files read: " + counterFiles++);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error message: " + ex.Message);
            }
        }
    }
}