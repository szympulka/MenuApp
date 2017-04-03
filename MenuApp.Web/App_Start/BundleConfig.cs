using System.Web;
using System.Web.Optimization;

namespace MenuApp.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Breakfast").Include(
             "~/Content/HomeContent/Breakfast.css",
             "~/Content/Commons/IndexCommon.css"
                ));
            bundles.Add(new ScriptBundle("~/Breakfast").Include(
                "~/scripts/Home/Home.js",
                "~/scripts/Commons/AjaxCommons.js"
                ));
           BundleTable.EnableOptimizations = true;
        }
    }
}