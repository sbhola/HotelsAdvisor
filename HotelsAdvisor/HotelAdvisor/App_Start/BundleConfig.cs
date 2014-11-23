using System.Web.Optimization;

namespace HotelsAdvisor
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/autocomplete/css").IncludeDirectory("~/Content/", "*.CSS", true));
            bundles.Add(new StyleBundle("~/autocomplete/jquery-ui/css").IncludeDirectory("~/Content/ui-lightness", "*.CSS", true));
            bundles.Add(new ScriptBundle("~/autocomplete/js").IncludeDirectory("~/Scripts", "*.js"));
            bundles.Add(new StyleBundle("~/bundles/css").IncludeDirectory("~/minimized", "*.css", true));

            bundles.Add(new ScriptBundle("~/assets/js").IncludeDirectory("~/assets/js", "*.js", true));
            bundles.Add(new ScriptBundle("~/assets/js/demo_travelnxt").IncludeDirectory("~/assets/js/demo_travelnxt", "*.js", true));
            //bundles.Add(new ScriptBundle("~/assets/js/google-code-prettify").IncludeDirectory("~/assets/js/google-code-prettify", "*.js", true));
            bundles.Add(new ScriptBundle("~/standardized-theme/Theme").IncludeDirectory("~/standardized-theme/Theme", "*.js", true));
            //bundles.Add(new ScriptBundle("~/standardized-theme/Theme/DiscountHotel/Layouts/IndexStyles/js").IncludeDirectory("~/standardized-theme/Theme/DiscountHotel/Layouts/IndexStyles/js", "*.js", true));
            //bundles.Add(new ScriptBundle("~/standardized-theme/Theme/WLC/Layouts/IndexStyles/js").IncludeDirectory("~/standardized-theme/Theme/WLC/Layouts/IndexStyles/js", "*.js", true));




            bundles.Add(new StyleBundle("~/assets/css").IncludeDirectory("~/assets/css", "*.css", true));
            //bundles.Add(new StyleBundle("~/assets/css/demo_travelnxt").IncludeDirectory("~/assets/css/demo_travelnxt", "*.css", true));
            bundles.Add(new StyleBundle("~/standardized-theme/Theme").IncludeDirectory("~/standardized-theme/Theme", "*.css", true));
            //bundles.Add(new StyleBundle("~/standardized-theme/Theme/Default/assets/css/user").IncludeDirectory("~/standardized-theme/Theme/Default/assets/css/user", "*.css", true));
            //bundles.Add(new StyleBundle("~/standardized-theme/Theme/styleguide/assets").IncludeDirectory("~/standardized-theme/Theme/styleguide/assets", "*.css", true));
            // bundles.Add(new StyleBundle("~/standardized-theme/WLC/Layouts/IndexStyles/css").IncludeDirectory("~/standardized-theme/WLC/Layouts/IndexStyles/css", "*.css", true));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/justified-nav.css",
                      "~/Content/ui-lightness/jquery-ui-{version}.custom.css",
                      "~/Content/ui-lightness/jquery-ui-{version}.custom.min.css"));
        }
    }
}