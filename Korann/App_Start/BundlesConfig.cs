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
            bundles.Add(
                new ScriptBundle("~/bundles/app/vendors")
                    .Include(
                        "~/app/vendors/angular/angular.js",
                        "~/app/vendors/angular-resource/angular-resource.js",
                        "~/app/vendors/angular-bootstrap/ui-bootstrap-tpls.js",
                        "~/app/vendors/angular-ui-router/release/angular-ui-router.js",
                        "~/app/vendors/lodash/dist/lodash.js",
                        "~/app/vendors/checklist-model/checklist-model.js",
                        "~/app/vendors/ng-file-upload/angular-file-upload.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/app/scripts")
                    .Include("~/app/scripts/main.js")
                    .IncludeDirectory("~/app/scripts/", "*.js", searchSubdirectories: true));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/bundles/bootstrap")
                    .Include("~/app/vendors/bootstrap/dist/css/bootstrap.css"));

            bundles.Add(
                new StyleBundle("~/bundles/app/styles")
                    .IncludeDirectory("~/app/styles/", "*.css", searchSubdirectories: true));
        }
    }
}