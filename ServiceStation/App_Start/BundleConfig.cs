using System.Web.Optimization;

namespace ServiceStation
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            #region Bundle Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/")
                .Include("~/Scripts/")
                .Include("~/Scripts/"));
            #endregion

            #region Bundle css
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/"));
            #endregion
        }
    }
}