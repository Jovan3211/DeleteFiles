using System;
using System.IO;
using System.Collections.Generic;

/*
    


*/

namespace Delete_files
{
    class Program
    {
        List<string> list = new List<string>();  //lista za file pathove

        static void versionprint()
        {
            Console.Clear();
            Console.WriteLine("1.0.0\n");
        }

        static bool readfile(string path)  //citanje putanji iz fajla
        {
            Program program = new Program();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (File.Exists(line))
                    {
                        program.list.Add(line);
                    }
                    else
                    {
                        Console.WriteLine("Error: Incorrect path.\n> {0}\n", line);
                    }
                }
            }

            versionprint(); Console.CursorVisible = false;
            Console.WriteLine("Do you wish to delete these files? (y/n)");
            ConsoleKey input = Console.ReadKey().Key;

            if (input == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void deletefiles()  //brisanje fajla iz putanja u listi
        {
            Program program = new Program();
            string path;

            for (int i = 0; i < program.list.Count; i++)
            {
                path = program.list[i];
                File.Delete(path);
            }
        }

        static void helpmenu()  //instrukcije
        {
            versionprint(); Console.CursorVisible = false;
            Console.WriteLine("The program takes a text document and reads all the");
            Console.WriteLine("file paths inside. If a file path is incorrect, it");
            Console.WriteLine("show an error. The other paths are correct, it will");
            Console.WriteLine("delete those files.\n\nPress any key to go back.");

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                versionprint(); Console.CursorVisible = true;
                Console.WriteLine("Type in the location of the text file or drag and drop:");
                Console.Write("(write '?' for help)\n> ");
                string path = Console.ReadLine();

                if (path.Contains("\""))  //omogucava drag and drop
                {
                    path = path.Replace("\"", "");
                }

                if (path == "?")
                {
                    helpmenu();
                }
                else
                {
                    if (File.Exists(path))  //gleda da li .txt fajl postoji
                    {
                        if (readfile(path))  //provera, ako je true brise fajlove
                        {
                            deletefiles();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThe inputed file path is invalid.");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
