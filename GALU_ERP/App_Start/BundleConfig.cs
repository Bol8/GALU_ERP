using System.Web;
using System.Web.Optimization;

namespace GALU_ERP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                      "~/bootstrap/css/bootstrap.css",
                      "~/bootstrap/css/Estilos.css"
                      ));

            bundles.Add(new StyleBundle("~/dist/css").Include(
                      "~/dist/css/AdminLTE.css",
                      "~/plugins/bootstrap-slider/slider.css",
                      "~/dist/css/skins/_all-skins.min.css",
                      "~/plugins/iCheck/flat/blue.css",
                      "~/plugins/morris/morris.css",
                      "~/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                      "~/plugins/datepicker/datepicker3.css",
                      "~/plugins/daterangepicker/daterangepicker-bs3.css",
                      "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                     "~/bootstrap/js/boostrap.js"
                     ));

            bundles.Add(new ScriptBundle("~/dist/js").Include(
                    "~/plugins/jQuery/jQuery-2.1.4.min.js",
                    "~/plugins/morris/morris.min.js",
                    "~/plugins/sparkline/jquery.sparkline.min.js",
                    "~/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                    "~/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                    "~/plugins/knob/jquery.knob.js",
                    "~/plugins/daterangepicker/daterangepicker.js",
                    "~/plugins/datepicker/bootstrap-datepicker.js",
                    "~/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                    "~/plugins/slimScroll/jquery.slimscroll.min.js",
                    "~/plugins/fastclick/fastclick.min.js",
                    "~/dist/js/app.min.js",
                    "~/dist/js/pages/dashboard.js",
                    "~/dist/js/demo.js"
                    ));

        }
    }
}
