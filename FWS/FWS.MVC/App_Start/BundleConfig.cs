using System.Web.Optimization;

namespace FWS.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            #region Main Page
            //Begin - Main Page
            bundles.Add(new ScriptBundle("~/bundles/js_0_0").Include(
                "~/Scripts/Main/pace/pace.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js_0_1").Include(
                "~/Scripts/Main/bootstrap/js/bootstrap.js",
                "~/Scripts/Main/jquery/jquery-1.9.1.js",
                "~/Scripts/Main/jquery/jquery-migrate-1.1.0.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/cross").Include(
                "~/Scripts/Main/crossbrowserjs/excanvas.min.js",
                "~/Scripts/Main/crossbrowserjs/html5shiv.js",
                "~/Scripts/Main/crossbrowserjs/respond.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js_0_2").Include(
                "~/Scripts/Main/jquery-cookie/jquery.cookie.js",
                "~/Scripts/Main/scrollMonitor/scrollMonitor.js",
                "~/Scripts/Main/apps.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                   "~/Content/Main/bootstrap/css/bootstrap.css",
                   "~/Content/Main/font-awesome/css/font-awesome.css",
                   "~/Content/Main/css/animate.css",
                   "~/Content/Main/css/style.css",
                   "~/Content/Main/css/style-responsive.css",
                   "~/Content/Main/css/theme/default.css"
                ));
            //End - Main Page
            #endregion

            #region Login
            bundles.Add(new StyleBundle("~/bundles/login/css").Include(
                "~/Content/Home/css/bootstrap/bootstrap.css",
                "~/Content/Home/css/libs/font-awesome.css",
                "~/Content/Home/css/libs/nanoscroller.css",
                "~/Content/Home/css/compiled/theme_styles.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/login/ie9").Include(
                "~/Scripts/Home/html5shiv.js",
                "~/Scripts/respond.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/login/js").Include(
                "~/Scripts/Home/jquery.js",
                "~/Scripts/Home/bootstrap.js",
                "~/Scripts/Home/jquery.nanoscroller.min.js",
                "~/Scripts/Home/scripts.js"
                ));
            #endregion



        }
    }
}
