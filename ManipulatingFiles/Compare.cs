using System;
using System.IO;
using System.Linq;

namespace ManipulatingFiles
{
    internal class Compare
    {
        internal static void CompareFileNames()
        {
            try
            {
                Console.WriteLine("\n========== Comparing File Names ==========");

                string pathToMoveFiles = Helper.EnterPath("Enter path to move the file(s): ");
                string pathToCompare = Helper.EnterPath("Enter path to compare the file(s): ");

                bool move = Helper.AskBool("Do you want to move those files from folder 1 present in folder 2 to a third folder? ");

                string pathToReceiveFiles = move ? Helper.EnterPath("Enter path to receive the file(s): ") : "";

                string[] filesFolder1 = Directory.GetFiles(pathToMoveFiles).Select(Path.GetFileName).ToArray();
                string[] filesFolder2 = Directory.GetFiles(pathToCompare).Select(Path.GetFileName).ToArray();

                Console.WriteLine("Files in both folders:");

                int counterFiles = 0;

                foreach (string file in filesFolder1)
                {
                    string extension = Path.GetExtension(file);
                    string fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    string matchingFile = Directory.GetFiles(pathToCompare, fileWithoutExtension + "*").FirstOrDefault();

                    if (!string.IsNullOrWhiteSpace(matchingFile))
                    {
                        counterFiles++;

                        if (!move)
                            Console.WriteLine($"{counterFiles} - {file}");
                        else
                        {
                            string sourceFilePath = Path.Combine(pathToMoveFiles, fileWithoutExtension + extension);
                            string destinationFilePath = Path.Combine(pathToReceiveFiles, fileWithoutExtension + extension);

                            File.Move(sourceFilePath, destinationFilePath);

                            Console.WriteLine($"{counterFiles} - File '{file}' copied to destination folder.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }
        }
    }
}