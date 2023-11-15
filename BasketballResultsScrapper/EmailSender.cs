using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BasketballResultsScrapper
{
    internal class EmailSender
    {
        //this method will send an email using the provided credentials
        public void SendEmail(string senderEmail, string senderPassword, string to, string subject, string body)
        {
            // Create a new SmtpClient instance
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587; // Use port 587 for TLS
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);
            client.EnableSsl = true;

            // Create a new MailMessage instance
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

     
     
            // Send the email
            try
            {
                client.Send(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
    }
