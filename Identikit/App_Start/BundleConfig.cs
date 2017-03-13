using System.Web;
using System.Web.Optimization;

namespace Identikit
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle(Constants.BootstrapStyleBundle).Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle(Constants.LoginStylesBundle).Include(
                      "~/Content/Login/Login.less"));

            bundles.Add(new StyleBundle(Constants.LayoutStylesBundle).Include(
                      "~/Content/Layout/Layout.css"));
        }
    }
}
