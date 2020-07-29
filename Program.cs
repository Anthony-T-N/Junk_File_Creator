using System;
using System.IO;

namespace Junk_File_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program main_program = new Program();
            main_program.menu();
            Program.create_junk_file();
        }
        public void menu()
        {
            System.Console.WriteLine("Welcome to the 'Junk_File_Creator'");
            System.Console.WriteLine("Please select one of the following option: ");
            while (false)
            {
                System.Console.WriteLine(" ");
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
    }
}
