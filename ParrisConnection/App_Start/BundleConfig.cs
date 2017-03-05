using System.Web.Optimization;

namespace ParrisConnection
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                        "~/Scripts/locales/bootstrap-datepicker.en-GB.min.js",
                        "~/Scripts/CustomScripts/ProfileScripts.js"                   
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/semantic.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/wall").Include(
                "~/Scripts/Plugins/EventCalendar/zabuto_calendar.js",
                "~/Scripts/CustomScripts/WallScripts.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/semantic.min.css",
                      "~/Content/site.css",
                      "~/Scripts/Plugins/EventCalendar/zabuto_calendar.min.css"
                      ));
        }
    }
}
