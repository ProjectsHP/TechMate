﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace WCF_Service_Server_
{
    public class MailSender
    {
        public MailSender() { }

        public int sendTextMail(string receiverEmail, string subject, string body)
        {

            string emailAddress = "hlulankubayi@gmail.com";
            string password = "ybaihxcmbgrejngh";
            //Object to fill up email data
            MimeMessage mimeMessage = new MimeMessage();
            //sending from
            mimeMessage.From.Add(new MailboxAddress("Prince", "hlulankubayi@gmail.com"));
            //sending to
            mimeMessage.To.Add(MailboxAddress.Parse("ph.kubaye@gmail.com"));
            //message subject
            mimeMessage.Subject = "Ey dawg WORKS";

            mimeMessage.Body = new TextPart("plain")
            {
                Text = @"This is my shandis bro"
            };
         
            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(emailAddress, password);
                smtpClient.Send(mimeMessage);
                Console.WriteLine("Email sent");
                return 1;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
           

        }
    }
}