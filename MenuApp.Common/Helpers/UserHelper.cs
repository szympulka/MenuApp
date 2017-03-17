using System.Web;


namespace MenuApp.Common.Helpers
{
    public class UserHelper
    {
        public static string UserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}