using System.Web;
using System.Web.Optimization;

namespace Karma
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/js/vendor/jquery-2.2.4.min.js",
                        "~/Content/js/vendor/bootstrap.min.js",
                        "~/Content/js/jquery.ajaxchimp.min.js",
                        "~/Content/js/jquery.nice-select.min.js",
                        "~/Content/js/jquery.sticky.js",
                        "~/Content/js/nouislider.min.js",
                        "~/Content/js/countdown.js",
                        "~/Content/js/jquery.magnific-popup.min.js",
                        "~/Content/js/owl.carousel.min.js",
                        "~/Content/js/gmaps.min.js", 
                        //"~/Content/js/minicart.js",
                        "~/Content/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/main.css",
                      "~/Content/css/linearicons.css",
                     "~/Content/css/font-awesome.min.css",
                     "~/Content/css/themify-icons.css",
                      "~/Content/css/bootstrap.css",
                    "~/Content/css/owl.carousel.css",
                     "~/Content/css/nice-select.css",
                     "~/Content/css/nouislider.min.css",
                     "~/Content/css/ion.rangeSlider.css",
                     "~/Content/css/ion.rangeSlider.skinFlat.css",
                     "~/Content/css/magnific-popup.css"));
        }
    }
}
