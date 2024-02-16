﻿using System;
using System.IO;

namespace FindString
{
    public class Helper
    {
        public static bool AskBool(string question)
        {
            bool boolToReturn;
            Console.Write(question);

            while (true)
            {
                string answer = Console.ReadLine();
                if (answer != null && (answer == "y" || answer == "Y"))
                {
                    boolToReturn = true;
                    break;
                }
                else if (answer != null && (answer == "n" || answer == "N"))
                {
                    boolToReturn = false;
                    break;
                }
                else
                    Console.Write($"Only y, Y, n or N allowed. {question}");
            }

            return boolToReturn;
        }

        public static int AskInt(string question)
        {
            int intToReturn;
            Console.Write(question);

            while (true)
            {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out intToReturn))
                    break;
                else
                    Console.Write($"Only number allowed. {question}");
            }

            return intToReturn;
        }

        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            var dir = new DirectoryInfo(sourcePath);
            Directory.CreateDirectory(destinationPath);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationPath, file.Name);
                file.CopyTo(targetFilePath);
            }
        }

        public static string InsertPath()
        {
            Console.Write("Insert path: ");
            string path;

            while (true)
            {
                path = Console.ReadLine();

                if (!Directory.Exists(path))
                    Console.WriteLine("Path does not exist or it was written wrongly. Insert path.");
                else
                    break;
            }

            return path;
        }

        public static void WriteAllLinesBetter(string path, params string[] lines)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (lines == null)
                throw new ArgumentNullException("lines");

            using (var stream = File.OpenWrite(path))
            {
                stream.SetLength(0);
                using (var writer = new StreamWriter(stream))
                {
                    if (lines.Length > 0)
                    {
                        for (var i = 0; i < lines.Length - 1; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                        writer.Write(lines[lines.Length - 1]);
                    }
                }
            }
        }
    }
}