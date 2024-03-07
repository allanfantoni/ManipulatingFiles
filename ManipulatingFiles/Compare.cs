using System;
using System.IO;
using System.Linq;

namespace ManipulatingFiles
{
    public class Compare
    {
        public static void CompareFileNames()
        {
            try
            {
                Console.WriteLine("========== Comparing File Names ==========");

                string pathToMoveFiles = Helper.InsertPath();
                string pathToCompare = Helper.InsertPath();
                string pathToReceiveFiles = "";

                bool move = Helper.AskBool("Do you want to move those files from folder 1 not in folder 2 to a third folder? ");

                if (move)
                    pathToReceiveFiles = Helper.InsertPath();

                string[] filesFolder1 = Directory.GetFiles(pathToMoveFiles).Select(Path.GetFileName).ToArray();
                string[] filesFolder2 = Directory.GetFiles(pathToCompare).Select(Path.GetFileName).ToArray();

                Console.WriteLine("Files in folder 1 and in folder 2:");

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

                            Console.WriteLine($"{counterFiles} - File '{file}' copied to folder 3.");
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