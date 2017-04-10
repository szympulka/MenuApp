using System;
using System.Threading.Tasks;
using MenuApp.Services.MailService;

namespace MenuApp.Services.Fakes
{
    public class MailServiceFake: IMailService
    {
        public void SendMail_Gmail(string userMail, string title, string message)
        {
            
        }

        public void SendMail_Sendgrid(string userMail, string title, string message)
        {
            
        }

        public void SendTemplate()
        {
    
        }

        public Task SendNewsletter()
        {
            throw new NotImplementedException();
        }
    }
}
