using System;
using System.IO;
using System.Timers;
using System.Collections.Generic;

namespace Junk_File_Creator
{
    class Program
    {
        // Use common file extensions.
        // Control file size.
        static void Main(string[] args)
        {
            Program main_program = new Program();
            main_program.menu();
        }
        // Get the current directory.
        string current_path = System.AppDomain.CurrentDomain.BaseDirectory;
        bool use_file_ext = false;
        public void menu()
        {
            System.Console.WriteLine("Author: Anthony-T-N");
            System.Console.WriteLine("Welcome to the 'Junk_File_Creator'");
            System.Console.WriteLine("Please select one of the following option: ");
            while (true)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("-------------------------------------------------------------------------");
                System.Console.WriteLine("1) Single Junk File: ");
                System.Console.WriteLine("2) Mutiple Junk Files: ");
                System.Console.WriteLine("3) Periodically generate Junk Files: ");
                System.Console.WriteLine("4) Change directory path: ");
                System.Console.WriteLine("5) File extensions switch ");
                System.Console.WriteLine("6) Exit program.");
                System.Console.WriteLine("");
                System.Console.WriteLine("Current directory_path: " + current_path);
                System.Console.WriteLine("Use existing file extensions: " + use_file_ext);
                System.Console.WriteLine("-------------------------------------------------------------------------");
                string user_input = Console.ReadLine();
                int converted_user_input = 0;
                try
                {
                    converted_user_input = Convert.ToInt32(user_input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"[-] Unable to parse '{user_input}'");
                }
                if (converted_user_input == 1)
                {
                    create_junk_file(current_path);
                }
                else if (converted_user_input == 2)
                {
                    Console.WriteLine("Amount to create: ");
                    try
                    {
                        int amount = Convert.ToInt32(Console.ReadLine());
                        mutiple_junk_files(amount, current_path);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("[-] Unable to parse");
                    }
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
                    System.Console.WriteLine("Enter new path directory");
                    string temp_current_path = @"" + Console.ReadLine();
                    if (Directory.Exists(current_path))
                    {
                        current_path = temp_current_path;
                        System.Console.WriteLine("[+] Legal path directory");
                    }
                    else
                    {
                        System.Console.WriteLine($"[-] Invalid path directory: '{temp_current_path}'");
                    }
                }
                else if (converted_user_input == 5)
                {
                    if (use_file_ext == false)
                    {
                        use_file_ext = true;
                    }
                    else
                    {
                        use_file_ext = false;
                    }
                }
                else if (converted_user_input == 6)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("[-] Invalid Input - Please Try Again");
                }
            }
        }
        private void periodical_creation(object sender, ElapsedEventArgs e)
        {
            create_junk_file(current_path);
        }

        private void mutiple_junk_files(int amount, string current_path)
        {
            for (int i = 0; i <= amount - 1; i++)
            {
                create_junk_file(current_path);
            }
        }
        public void create_junk_file(string current_path)
        {
            string file_name = current_path + file_name_generator(use_file_ext);
            System.Console.WriteLine("[+] " + file_name);
            if (File.Exists(file_name))
            {
                Console.WriteLine($"[-] {file_name} already exists!");
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
        public static string file_name_generator(bool use_file_ext)
        {
            List<string> common_file_ext = new List<string>()
            {
                "mp3", "wav", "ogg", "mpa", "wma", "zip", "rar", 
                "7z", "bin", "iso", "csv", "log", "dat", "ico", 
                "jpeg", "png", "svg", "html", "mp4", "flv", "mpg", 
                "swf", "wmv", "mov", "m4v", "mkv", "avi"
            };
            List<char> generated_name = new List<char>();
            string char_string = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var rand = new Random();
            string final_string = "";
            for (int i = 0; i <= rand.Next(0, 5); i++)
            {
                generated_name.Add(char_string[rand.Next(0, char_string.Length)]);
            }
            generated_name.Add('.');
            if (use_file_ext == true)
            {
                final_string = string.Join("", generated_name) + common_file_ext[rand.Next(0, common_file_ext.Count - 1)]; ;
            }
            else
            {
                for (int i = 0; i <= rand.Next(0, 3); i++)
                {
                    generated_name.Add(char_string[rand.Next(0, char_string.Length)]);
                }
                final_string = string.Join("", generated_name);
            }
            return final_string;
        }
    }
}
