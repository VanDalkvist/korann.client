using System.Web.Optimization;

namespace Korann.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);

            RegisterStyleBundles(bundles);
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            // register scripts from references

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/references/angular/angular.js",
                "~/Scripts/references/angular/angular-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular-extensions").IncludeDirectory(
                "~/Scripts/references/angular.extensions/", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/bundles/jquery").IncludeDirectory(
                "~/Scripts/references/jquery", "*.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/optimization").Include(
                "~/Scripts/references/optimization/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").IncludeDirectory(
                "~/Scripts/references/bootstrap/", "*.js"));

            // register application scripts

            bundles.Add(new ScriptBundle("~/bundles/app").IncludeDirectory(
                "~/Scripts/app/", "*.js", searchSubdirectories: true));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles").IncludeDirectory(
                "~/Content/styles/", "*.css", searchSubdirectories: true));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-styles").IncludeDirectory(
                "~/Content/bootstrap", "*.css", searchSubdirectories: true));
        }
    }
}