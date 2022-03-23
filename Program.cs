using System;
using System.IO;

namespace SingIN
{
    internal class Program
    {
        static void header()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("*        Sign In / Sign Up        *");
            Console.WriteLine("***********************************");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                header();
                int option = menu();
                if (option == 1)
                {
                    Console.WriteLine("Enter Username :");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password :");
                    string password = Console.ReadLine();
                    signIn(username, password);
                    Console.WriteLine("Press any Key To Continue...");
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Username :");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password :");
                    string password = Console.ReadLine();
                    signUp(username, password);
                    Console.WriteLine("Account Created Successfully.");
                    Console.WriteLine("Press any Key To Continue...");
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option.");
                }
                Console.Clear();
            }

        }
        static int menu()
        {
            Console.WriteLine("Choose One Option : ");
            Console.WriteLine("1.Sign In  ");
            Console.WriteLine("2.Sign Up  ");
            Console.WriteLine("3.Exit  ");
            Console.Write("Your Option : ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        static void signIn(string username, string password)
        {
            bool found = false;
            string path = "passwords.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string user = parseData(line, 1);
                    string pass = parseData(line, 2);
                    if (user == username && pass == password)
                    {
                        found = true;
                    }
                }
                sr.Close();

            }
            else
            {
                Console.WriteLine("File Not found.");
            }
            if (!found)
            {
                Console.WriteLine("Invalid Username  or Password.");
            }
            else
            {
                Console.WriteLine("Login Succesful.");
            }

        }
        static void signUp(string username, string password)
        {
            string path = "passwords.txt";
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(username + "," + password);
            sw.Flush();
            sw.Close();
        }
        static string parseData(string line, int field)
        {
            string req = "";
            int count = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    count++;
                }
                else if (field == count)
                {
                    req = req + line[i];
                }
            }
            return req;
        }
    }
}