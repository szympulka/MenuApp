using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Services.Fakes.MailService
{
    public class MailServiceFake : IMailServiceFake
    {
        public void SendMail_Gmail(string userMail, string title, string message)
        {
           
        }

        public void SendMail_Sendgrid(string userMail, string title, string message)
        {
            var asd = message;
            var asdf = title;
        }

        public void SendTemplate()
        {
           
        }
    }
}
