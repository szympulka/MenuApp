using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Services.Fakes.MailService
{
    public interface IMailServiceFake
    {
        void SendMail_Gmail(string userMail, string title, string message);
        void SendMail_Sendgrid(string userMail, string title, string message);
        void SendTemplate();
    }
}
