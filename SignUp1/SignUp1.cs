using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SignUp1
{
    public class UserManager
    {
        public static string Email;
        public static string FullName;
        public static string Password;
        public static string FirstName;
        public static string LastName;
        public static int selection;
        public static string FilePath = @"C:\Users\oyins\Desktop\Oyinda\FilesFolder\";

        public static void HomeScreen()
        {
            Console.WriteLine("Welcome to Sukoko App\nPlease Select a valid Option:\nPress 1 for Registration\nPress 2 for Login\nPress 3 to close the application.");
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                UserRegister();
            }
            else if (selection == 2)
            {
                UserLogin();
            }
            else if (selection == 3)
            {
                Console.WriteLine("Thank you for using our application");
                Thread.Sleep(3000);
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Incorrect Entry.Try Again");
            }
        }

        public static void UserRegister()
        {
            Console.WriteLine("Please fill in your details.");

            Console.WriteLine("FullName:");
            FullName = Console.ReadLine();
            Console.WriteLine("Email Address:");
            Email = Console.ReadLine();
            Console.WriteLine("Password:");
            Password = Console.ReadLine();

            if (File.Exists($"{FilePath}{Email}.txt"))
            {
                Console.WriteLine("You have already registered");
                HomeScreen();
            }
            else
            {
                using (StreamWriter sw = File.AppendText($"{FilePath}{Email}.txt"))
                {
                    sw.WriteLine(FullName);
                    sw.WriteLine(Email);
                    sw.WriteLine(Password);
                }
                Console.WriteLine("Thank you for Registering to our app");
                HomeScreen();
            }
        }

        public static void UserLogin()
        {
            Console.WriteLine("Welcome to the Login Screen.\nPlease provide your login details.");

            Console.WriteLine("Email Address:");
            Email = Console.ReadLine();
            Console.WriteLine("Password:");
            Password = Console.ReadLine();

            if (File.Exists($"{FilePath}{Email}.txt"))
            {
                string[] checkfile = File.ReadAllLines($"{FilePath}{Email}.txt");

                if (Password == checkfile[2])
                {
                    Console.WriteLine("Welcome to Sukoko App\n====================\n");
                }
                else
                {
                    Console.WriteLine("Incorrect Password..Try again.\n====\n");
                    HomeScreen();
                }
            }
            else
            {
                Console.WriteLine("Account not found");
                Console.WriteLine("Please proceed to registeration first");
                HomeScreen();
            }
        }
    }

    /* DirectoryInfo di = new DirectoryInfo(@"C:\Users\oyins\Desktop\Oyinda\FilesFolder");

             if (di.Exists)
             {
                 // Indicate that the directory already exists.
                 Console.WriteLine("That path exists already.");
                 return;
             }

             // Try to create the directory.
             di.Create();
             Console.WriteLine("The directory was created successfully.");
    
             Console.WriteLine("Thank you for Registering to our app");
             string[] lines = File.ReadAllLines($"{FilePath}{Email}.txt");
             Console.WriteLine("Contents of the file = ");
             foreach (string line in lines)
             {
                Console.WriteLine(line);
             }
    */
}
