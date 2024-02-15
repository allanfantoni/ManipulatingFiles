using System;
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
                    Console.Write("Only number allowed.");
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
    }
}