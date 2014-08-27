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
            // register vendors

            bundles.Add(
                new ScriptBundle("~/bundles/angular")
                    .Include(
                        "~/vendors/angular/angular.js",
                        "~/vendors/angular-resource/angular-resource.js",
                        "~/vendors/angular-bootstrap/ui-bootstrap-tpls.js",
                        "~/vendors/angular-ui-router/release/angular-ui-router.js",
                        "~/vendors/lodash/dist/lodash.js",
                        "~/vendors/checklist-model/checklist-model.js",
                        "~/vendors/ng-file-upload/angular-file-upload.js"));

            // register application scripts

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app/main.js")
                .IncludeDirectory("~/app/", "*.js", searchSubdirectories: true));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles").IncludeDirectory(
                "~/Content/styles/", "*.css", searchSubdirectories: true));

            // todo: style from vendors
//            bundles.Add(new StyleBundle("~/bundles/bootstrap-styles").IncludeDirectory(
//                "~/Content/bootstrap", "*.css", searchSubdirectories: true));
        }
    }
}