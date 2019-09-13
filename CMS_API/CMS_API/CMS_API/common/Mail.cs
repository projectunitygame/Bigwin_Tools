using AegisImplicitMail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace api_cms.common
{
    public class Mail
    {
        private static string host = WebConfigurationManager.AppSettings["smtp_host"];
        private static int port = int.Parse(WebConfigurationManager.AppSettings["smtp_port"]);
        private static string[] userName = WebConfigurationManager.AppSettings["mailList"].Split(',');
        private static string password = WebConfigurationManager.AppSettings["mail_pwd"];
        private static string mailReport = WebConfigurationManager.AppSettings["MailReport"];
        private static string ServerType = WebConfigurationManager.AppSettings["SERVER_TYPE"];
        private static string SSL = WebConfigurationManager.AppSettings["SSL"];
        public static void SendEmail(string subject, string message, string userTo)
        {
            try
            {
                subject = UtilClass.RemoveSign4VietnameseString(subject);
                userTo = userTo.ToLower();
                //Generate Message 
                if (userName.Count() == 0 || string.IsNullOrEmpty(host))
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
                mailer.SslType = SslMode.Ssl;
                mailer.AuthenticationMode = AuthenticationType.Base64;

                //Set a delegate function for call back
                mailer.SendCompleted += compEvent;
                mailer.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR SendEmail: " + ex);
            }
        }
        public static void SendReport(string subject, string message)
        {
            try
            {
                subject = UtilClass.RemoveSign4VietnameseString(subject);
                var userTo = mailReport.Split(',').ToList();
                for (int i = 0; i < userTo.Count; i++)
                {
                    //Generate Message 
                    if (userName.Count() == 0)
                        return;
                    var mailMessage = new MimeMailMessage();
                    string smtpUserName = userName[UtilClass.GetRandomNumber(0, userName.Count() - 1)];
                    mailMessage.From = new MimeMailAddress(smtpUserName);
                    mailMessage.To.Add(userTo[i]);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = ServerType + " " + subject;
                    mailMessage.Body = message;

                    //Create Smtp Client
                    var mailer = new MimeMailer(host, port);
                    mailer.User = smtpUserName;
                    mailer.Password = password;
                    if (SSL == "true")
                        mailer.SslType = SslMode.Ssl;
                    else
                        mailer.SslType = SslMode.None;
                    mailer.AuthenticationMode = AuthenticationType.Base64;

                    //Set a delegate function for call back
                    mailer.SendCompleted += compEvent;
                    mailer.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR SendReport: " + ex);
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