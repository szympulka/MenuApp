using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MenuApp.Web.App_Start;
using System.Web.Optimization;

namespace MenuApp.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.Configure();
        }
    }
}