using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using MenuApp.Common;
using MenuApp.Common.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;
using MenuApp.Services.LogService;
using MenuWeb.Core.Entities;
using Castle.DynamicProxy;

namespace MenuApp.Services.MailService
{

    public class MailService : IMailService
    {
        private ILogService _logService;

        public MailService(ILogService logService)
        {
            _logService = logService;
        }

        public void SendMail_Gmail(string userMail, string title, string message)
        {
            string Mail = WebConfigurationManager.AppSettings["SendMailGmail"];
            //ConfigurationSettings.AppSettings["SendMailGmail"];
            var apiKey = Mail.Split(';');
            MailMessage mail = new MailMessage();
            mail.To.Add(userMail);
            mail.From = new MailAddress(apiKey[0], title, Encoding.UTF8);
            mail.Subject = title;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = message;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(apiKey[0], apiKey[1]);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                var date = new DateTimeHelper();
                Log log = new Log();
                log.DateLog = date.ServerTime();
                log.Error = ex.Message;
                log.UserDateLog = date.LocalDateTime();
                log.FunctionArgumnets = userMail + ";" + title + ";" + message;
                log.ErrorPlace = "MailService/SendMail_Gmail";
                _logService.addLog(log);
            }
        }

        public void SendMail_Sendgrid(string userMail, string title, string message)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();
                // To
                mailMsg.To.Add(new MailAddress(userMail, "To You"));
                // From
                mailMsg.From = new MailAddress("szympulka@gmail.com", "YourRecipes");
                // Subject and multipart/alternative Body
                mailMsg.Subject = title;
                string text = "text body";
                string html = message;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null,
                    MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null,
                    MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                NetworkCredential credentials = new NetworkCredential(Consts.SendGrid_Login,Consts.SendGrid_Password);
                smtpClient.Credentials = credentials;
                smtpClient.Send(mailMsg);
            }

            catch (Exception ex)
            {
                //SendMail_Gmail(userMail, title, message);
                var date = new DateTimeHelper();
                Log log = new Log();
                log.StackTrace = ex.StackTrace;
                log.DateLog = date.ServerTime();
                log.UserDateLog = date.LocalDateTime();
                log.Error = ex.Message;
                log.FunctionArgumnets = userMail + ";" + title + ";" + message;
                log.ErrorPlace = "MailService/SendMail_Sendgrid";
                _logService.addLog(log);
            }
        }

        public void SendTemplate()
        {
            throw new NotImplementedException();
        }

        public async Task SendNewsletter()
        {
            try
            {
                dynamic sg = new SendGridAPIClient(Consts.SendGrid_ApiKey, "https://api.sendgrid.com");
                Email from = new Email("pulson666@gmail.com");
                string subject = "Sending with SendGrid is Fun";
                Email to = new Email("pulson666@gmail.com");
                Content content = new Content("text/plain", "and easy to do anywhere, even with C#");
                Mail mail = new Mail(from, subject, to, content);
                mail.TemplateId = Consts.SendGrid_TemplateKey_Newsletter;
                dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
            }
            catch (Exception ex)
            {
                var date = new DateTimeHelper();
                Log log = new Log();
                log.DateLog = date.ServerTime();
                log.UserDateLog = date.LocalDateTime();
                log.Error = ex.Message;
                log.ErrorPlace = "MailServie/SendNewsletter";
                _logService.addLog(log);
            }
        }

    }
}

