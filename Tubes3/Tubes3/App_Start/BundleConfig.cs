using System.Web;
using System.Web.Optimization;

namespace Tubes3
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/countdown.js",
                      "~/Scripts/gmap.js",
                      "~/Scripts/jquery.js",
                      "~/Scripts/scripts.js",
                      "~/Scripts/waypoints.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/animations.css",
                      "~/Content/buttons.css",
                      "~/Content/percentagebar.css",
                      "~/Content/reset.css",
                      "~/Content/style.css"));
        }
    }
}
