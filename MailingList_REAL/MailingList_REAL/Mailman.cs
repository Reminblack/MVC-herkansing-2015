using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace MailingList_REAL
{
    public static class Mailman
    {

        public static void SendMail(String sender, String receiver, String subject, String message)
        {
            //create the mail message
            MailMessage mail = new MailMessage();

            //set the addresses
            mail.From = new MailAddress(sender);
            mail.To.Add(receiver);

            //set the content
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            //send the message
            var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("mailadress", "password"),
                    EnableSsl = true
                };
            smtp.Send(mail);
        }

        public static void SendMail(String sender, List<String> receivers, String subject, String message, Boolean cc)
        {
            if (cc)
            {
                //create the mail message
                MailMessage mail = new MailMessage();

                //set the addresses
                mail.From = new MailAddress(sender);
                foreach (String receiver in receivers)
                {
                    mail.To.Add(receiver);
                }

                //set the content
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                //send the message
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                NetworkCredential basicCredential = new NetworkCredential("mailaddress", "password");
                smtp.Send(mail);
            }
            else
            {
                foreach (String receiver in receivers)
                {
                    SendMail(sender, receiver, subject, message);
                }
            }
        }
    }
}