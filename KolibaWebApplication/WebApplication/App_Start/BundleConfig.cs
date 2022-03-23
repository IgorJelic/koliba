using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            // Custom bundles //

            // HOME CONTROLLER
            // style bundle
            bundles.Add(new StyleBundle("~/Content/home").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/home.css"));

            // script bundle
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                "~/Scripts/home-script.js"));

            // MENU CONTROLLER
            // style bundle
            bundles.Add(new StyleBundle("~/Content/menu").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/menu.css"));

            // script bundle
            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                "~/Scripts/menu-script.js"));

            // ORDER CONTROLLER
            // style bundle
            bundles.Add(new StyleBundle("~/Content/order").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/order.css"));

            // script bundle
            bundles.Add(new ScriptBundle("~/bundles/order").Include(
                "~/Scripts/order-script.js"));

            // CONTACT CONTROLLER
            // style bundle
            bundles.Add(new StyleBundle("~/Content/contact").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/contact.css"));

            // script bundle
            bundles.Add(new ScriptBundle("~/bundles/contact").Include(
                "~/Scripts/contact-script.js"));

            // SALESMANS CONTROLLER
            // style bundle
            bundles.Add(new StyleBundle("~/Content/employees").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/employees.css"));

            // script bundle
            bundles.Add(new ScriptBundle("~/bundles/employees").Include(
                "~/Scripts/employees-script.js"));
        }
    }
}
