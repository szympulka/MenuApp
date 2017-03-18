namespace MenuApp.Services.Fakes.MailService
{
    public interface IMailServiceFake
    {
        void SendMail_Gmail(string userMail, string title, string message);
        void SendMail_Sendgrid(string userMail, string title, string message);
        void SendTemplate();
    }
}
