using System;
using System.IO;

namespace FindString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Manipulating Files ==========");
            Console.WriteLine("Choose an option: \n1- Find string in files. \n2- Rename files.");
            int option = int.Parse(Console.ReadLine());

            if (option != 1 && option != 2)
            {
                Console.WriteLine("Option does not exist.");
                Console.WriteLine("Press any key to close the window.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (option == 1)
                Search.SearchForString();
            else if (option == 2)
                Rename.RenameFiles();

            Console.WriteLine("Press any key to close the window.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}