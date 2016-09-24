using System.Web.Optimization;

namespace ServiceStation
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            #region Bundle Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.1.0.js")
                .Include("~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizer")
                .Include("~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/validate")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js"));
            #endregion

            #region Bundle css
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/css/sb-admin.css"));
            #endregion

            BundleTable.EnableOptimizations = true;
        }
    }
}