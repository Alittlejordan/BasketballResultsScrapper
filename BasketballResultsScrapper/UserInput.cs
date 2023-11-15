using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasketballResultsScrapper
{
    internal class UserInput
    {
        public string data;
        BasketballReferenceScrapper scraper = new BasketballReferenceScrapper();
        EmailSender emailSender = new EmailSender();

        //this method will display the main menu and will call the appropriate methods based on the user's choice
        public void MainMenu()
        {
            Console.WriteLine("\nWelcome to the Basketball Results Scrapper!\n");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Scrape Current games from basketball-reference.com");
            Console.WriteLine("2. Scrape Data from basketball-reference.com");
            Console.WriteLine("3. Send email with scraped data");
            Console.WriteLine("3. Exit");

            Console.WriteLine();

            Console.Write("Enter Your Choice:");

            while (true)
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ScrapRecentBasketBallGames();
                        break;
                    case "2":
                        ScrapData();
                        break;

                    case "3":
                        SendData();
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;


                }
            }


        }

        //this method will scrape the RecentGames from the basketball-reference.com website and return it as a string
        private void ScrapRecentBasketBallGames()
        {
            data = scraper.ScrapRecentBasketBallGames();
            Console.WriteLine(data);
            MainMenu();
        }

        //is a custom method that will scrape data from a webpage and return it as a string
        private void ScrapData()
        {
            data = scraper.ScrapeData();
            Console.WriteLine(data);
            MainMenu();
        }


        //this method will send the data to the email address provided by the user
        private void SendData()
        {
            if (data != null)
            {
                string senderEmail;
                do
                {
                    Console.WriteLine("Enter sender's email address: ");
                    senderEmail = Console.ReadLine();
                    Console.WriteLine();
                } while (string.IsNullOrWhiteSpace(senderEmail) || !IsValidEmail(senderEmail));

                // Get sender's email password securely
                Console.WriteLine("Enter sender's email password: ");
                string senderPassword = GetPassword();
                Console.WriteLine();

                // Get recipient's email address with validation
                string recipientEmail;
                do
                {
                    Console.WriteLine("Enter recipient's email address: ");
                    recipientEmail = Console.ReadLine();
                    Console.WriteLine();
                } while (string.IsNullOrWhiteSpace(recipientEmail) || !IsValidEmail(recipientEmail));

                // Get email subject
                Console.WriteLine("Enter email subject: ");
                string subject = Console.ReadLine();
                Console.WriteLine();


                // Send the email
                emailSender.SendEmail(senderEmail, senderPassword, recipientEmail, subject, data);


            }
            else
            {
                Console.WriteLine("No data to send");
                MainMenu();
            }
        }



        // Validate email address format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        static string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Append the character to the password (excluding Enter key)
                if (key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*"); // Display an asterisk for each character
                    
                }

            } while (key.Key != ConsoleKey.Enter);

            return password;
        }
    }
}

