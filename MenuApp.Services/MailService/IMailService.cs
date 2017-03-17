
using System.Threading.Tasks;

namespace MenuApp.Services.MailService
{
    public interface IMailService
    {
        void SendMail_Gmail(string userMail, string title, string message);
        void SendMail_Sendgrid(string userMail, string title, string message);
        void SendTemplate();
        Task SendNewsletter();
    }
}
