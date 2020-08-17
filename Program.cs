using System;
using System.IO;
using System.Timers;
using System.Collections.Generic;

namespace Junk_File_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program main_program = new Program();
            main_program.menu();
        }
        public void menu()
        {
            System.Console.WriteLine("Welcome to the 'Junk_File_Creator'");
            System.Console.WriteLine("Please select one of the following option: ");
            string current_path = "NIL";
            while (true)
            {
                Console.WriteLine("");
                Console.Write("1) Single Junk File: ");
                Console.Write("2) Mutiple Junk Files: ");
                Console.Write("3) Periodically generate Junk Files: ");
                Console.Write("4) Change directory path: ");
                Console.Write("5) Exit program.");
                Console.WriteLine("");
                Console.WriteLine("Current directory_path: " + current_path);
                Console.WriteLine("");
                string user_input = Console.ReadLine();
                int converted_user_input = 0;
                try
                {
                    converted_user_input = Convert.ToInt32(user_input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"[-] Unable to parse '{converted_user_input}'");
                }
                if (converted_user_input == 1)
                {
                    create_junk_file();
                }
                else if (converted_user_input == 2)
                {
                    Console.WriteLine("Amount to create: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    mutiple_junk_files(amount);
                }
                else if (converted_user_input == 3)
                {
                    Timer t = new Timer(TimeSpan.FromMinutes(0.1).TotalMilliseconds);
                    t.AutoReset = true;
                    t.Elapsed += new System.Timers.ElapsedEventHandler(periodical_creation);
                    t.Start();
                }
                else if (converted_user_input == 4)
                {
                    string entered_filepath = @"" + Console.ReadLine();
                    current_path = change_directory_path(entered_filepath);
                }
                else if (converted_user_input == 5)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("[-] Invalid Input - Please Try Again");
                }
            }
        }
        private static void periodical_creation(object sender, ElapsedEventArgs e)
        {
            create_junk_file();
        }

        private static void mutiple_junk_files(int amount)
        {
            for (int i = 0; i <= amount; i++)
            {
                create_junk_file();
            }
        }
        private static string change_directory_path(string current_path)
        {
            // @ = Verbatim String Literal (Escape is inapplicable)
            /*
            string temp_file_name = @":\Users\Anthony\Desktop\123.data";
            string temp_file_name = @":\Users\Anthony\source\repos\Junk_File_Creator\bin\Debug\netcoreapp3.1\Temp_Folder\";
            //Experimenting - Remove after.
            entered_filepath = temp_file_name + entered_filepath;
            entered_filepath = $@":\{entered_filepath}";
            System.Console.WriteLine(entered_filepath);
            System.Console.WriteLine(temp_file_name);
            return;
            */
            string temp_file_name = @":\Users\Anthony\Desktop\123.data";
            System.Console.WriteLine(current_path);
            System.Console.WriteLine(temp_file_name);
            System.Console.WriteLine(@"" + temp_file_name);
            return current_path;
        }

        public static void create_junk_file()
        {
            string file_name = file_name_generator();
            if (File.Exists(file_name))
            {
                Console.WriteLine($"{file_name} already exists!");
                return;
            }

            // Create a new file
            using (FileStream fs = new FileStream(file_name, FileMode.CreateNew))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    for (int i = 0; i < 50; i++)
                    {
                        w.Write(i.ToString());
                    }
                }
            }
        }
        public static string file_name_generator()
        {
            List<char> generated_name = new List<char>();
            string char_string = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var rand = new Random();
            for (int i = 0; i <= rand.Next(0, 5); i++)
            {
                generated_name.Add(char_string[rand.Next(0, char_string.Length)]);
            }
            generated_name.Add('.');
            for (int i = 0; i <= rand.Next(0, 3); i++)
            {
                generated_name.Add(char_string[rand.Next(0, char_string.Length)]);
            }
            string final_string = string.Join("", generated_name);
            System.Console.WriteLine(final_string);
            return final_string;
        }
    }
}
