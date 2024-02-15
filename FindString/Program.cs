using System;

namespace FindString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Manipulating Files ==========");
            Console.WriteLine("Choose an option: \n1- Find string in files. \n2- Rename files.");
            int option;

            while (true)
            {
                option = int.Parse(Console.ReadLine());

                if (option != 1 && option != 2)
                    Console.WriteLine("Option does not exist. Choose an option.");
                else
                    break;
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