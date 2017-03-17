using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MenuApp.Web.App_Start;

namespace MenuApp.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.Configure();
        }
    }
}