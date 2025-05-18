using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace ManipulatingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            int option;
            List<int> listOfOptions = new List<int> { 1, 2, 3, 4 };
            Console.WriteLine("========== Manipulating Files ==========\n");
            Console.WriteLine("Always make sure to perform a backup when renaming or changing file contents.\n");

            while (running)
            {
                option = Helper.AskInt("Choose an option: \n" +
                    "1- Find string in files \n" +
                    "2- Rename files \n" +
                    "3- Remove lines of files \n" +
                    "4- Compare file names in different folders \n");

                if (listOfOptions.IndexOf(option) == -1)
                    Console.WriteLine("Option does not exist.");
                else
                {
                    switch (option)
                    {
                        case 1:
                            Search.SearchForString();
                            break;
                        case 2:
                            Rename.RenameFiles();
                            break;
                        case 3:
                            Remove.RemoveLines();
                            break;
                        case 4:
                            Compare.CompareFileNames();
                            break;
                        default:
                            break;
                    }

                    bool performOtherOperation = Helper.AskBool("Do you want to choose another operation to do? ");
                    
                    if (!performOtherOperation)
                        running = false;
                }
            }

            Console.WriteLine("Press any key to close the window.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}