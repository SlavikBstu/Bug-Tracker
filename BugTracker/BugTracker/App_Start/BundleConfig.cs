using System.Web;
using System.Web.Optimization;

namespace BugTracker
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/gridMvc").Include(
                       "~/Scripts/gridmvc*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
         "~/Scripts/jquery.unobtrusive-ajax*"));
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles/bootstrap.css",
                      "~/Content/Styles/Site.css",
                      "~/Content/Styles/BT.css",
                      "~/Content/Styles/font-awesome/font-awesome.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/gridCss").Include(
                      "~/Content/Styles/Gridmvc.css"));
        }
    }
}
