using System;
using System.IO;
using System.Collections.Generic;

namespace Junk_File_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program main_program = new Program();
            main_program.menu();
            //Temp
            Program.create_junk_file();
        }
        public void menu()
        {
            System.Console.WriteLine("Welcome to the 'Junk_File_Creator'");
            System.Console.WriteLine("Please select one of the following option: ");
            while (false)
            {
                Console.WriteLine("");
                Console.Write("1) Single Junk File: ");
                Console.Write("2) Mutiple Junk Files: ");
                Console.Write("3) Periodically generate Junk Files:");
                Console.Write("4) Exit program.");
                Console.WriteLine("");
                string user_input = Console.ReadLine();
                int converted_user_input = 0;
                try
                {
                    converted_user_input = Convert.ToInt32(user_input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{converted_user_input}'");
                }
                if (converted_user_input == 1)
                {
                    ;
                }
                else if (converted_user_input == 2)
                {
                    ;
                }
                else if (converted_user_input == 3)
                {
                    ;
                }
                else
                {
                    Console.WriteLine("Invalid Input - Please Try Again");
                }
            }
        }
        public static void create_junk_file()
        {
            //string fileName = @":\Users\Anthony\Desktop\123.data";
            string fileName = "123.txt";
            if (File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} already exists!");
                return;
            }

            // Create a new file     
            using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    for (int i = 0; i < 11; i++)
                    {
                        w.Write(i);
                    }
                }
            }
        }
        public string file_name_generator()
        {
            List<string> generated_name = new List<string>();
            var rand = new Random();
            rand.Next(generated_name);
            for (int i = 0; i <= 5; i++)
            {

            }
            return "";
        }
    }
}
