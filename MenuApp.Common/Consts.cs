using System.Web.Configuration;

namespace MenuApp.Common
{
    public class Consts
    {
        #region SendGrid

        static string[] SendGrid = WebConfigurationManager.AppSettings["SendGridAzurePass"].Split(';');
        private static string SendGridApiKey = WebConfigurationManager.AppSettings["SendGridApiKey"];
        private static string SendGridTemplateKeyNewsletter = WebConfigurationManager.AppSettings["SendGridTemplateKeyNewsletter"];
        public static readonly string SendGrid_ApiKey = SendGridApiKey;
        public static readonly string SendGrid_TemplateKey_Newsletter = SendGridTemplateKeyNewsletter;
        public static readonly string SendGrid_Login = SendGrid[0];
        public static readonly string SendGrid_Password = SendGrid[1];

        #endregion
       
        #region Url
        public const string Url_Registration = "http://yourrecipes.azurewebsites.net/Authorization/ActivateAccount/";
        #endregion

        public static readonly string PrefixPhotoNameMain = "yourrecipes.com-Main-";
        public static readonly string PrefixPhotoName = "yourrecipes.com/-";
    }
}
