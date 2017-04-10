using System.Web.Optimization;

namespace MenuApp.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/BreakfastCSS").Include(
             "~/Content/HomeContent/Breakfast.css",
             "~/Content/Commons/IndexCommon.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/BreakfastJS").Include(               
                "~/scripts/Home/Home.js",
                "~/scripts/Commons/AjaxCommons.js",
                "~/scripts/Commons/AjaxCommons.js"
                ));
            BundleTable.EnableOptimizations = false;
        }
    }
}