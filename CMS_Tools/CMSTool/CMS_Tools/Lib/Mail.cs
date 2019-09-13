using AegisImplicitMail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CMS_Tools.Lib
{
    public class Mail
    {
        private static string host = WebConfigurationManager.AppSettings["smtp_host"];
        private static int port = int.Parse(WebConfigurationManager.AppSettings["smtp_port"]);
        private static string[] userName = WebConfigurationManager.AppSettings["mailList"].Split(',');
        private static string password = WebConfigurationManager.AppSettings["mail_pwd"];
        public static void SendEmail(string subject, string message, string userTo)
        {
            try
            {
                subject = UtilClass.RemoveSign4VietnameseString(subject);
                userTo = userTo.ToLower();
                //Generate Message 
                if (userName.Count() == 0)
                    return;
                var mailMessage = new MimeMailMessage();
                string smtpUserName = userName[UtilClass.GetRandomNumber(0, userName.Count() - 1)];
                mailMessage.From = new MimeMailAddress(smtpUserName);
                mailMessage.To.Add(userTo);
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                mailMessage.Body = message;

                //Create Smtp Client
                var mailer = new MimeMailer(host, port);
                mailer.User = smtpUserName;
                mailer.Password = password;
                mailer.SslType = port == 587 ? SslMode.None: SslMode.Ssl; //SslMode.Ssl;
                mailer.AuthenticationMode = AuthenticationType.Base64;

                //Set a delegate function for call back
                mailer.SendCompleted += compEvent;
                mailer.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        //Call back function
        private static void compEvent(object sender, AsyncCompletedEventArgs e)
        {
            //if (e.UserState != null)
            //    Console.Out.WriteLine(e.UserState.ToString());

            //Console.Out.WriteLine("is it canceled? " + e.Cancelled);

            //if (e.Error != null)
            //    Console.Out.WriteLine("Error : " + e.Error.Message);
        }
    }
}