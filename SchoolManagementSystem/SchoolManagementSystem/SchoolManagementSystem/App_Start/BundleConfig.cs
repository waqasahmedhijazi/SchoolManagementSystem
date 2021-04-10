using System.Web.Optimization;

namespace SchoolManagementSystem
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new StyleBundle("~/css/main-css").Include(
            //          "~/assets/css/bootstrap.min.css",
            //          "~/assets/css/app.min.css",

            //          "~/assets/css/bootstrap-dark.min.css",
            //          "~/assets/css/app-dark.min.css"));


            bundles.Add(new StyleBundle("~/css/icon-css").Include(
                      "~/assets/css/icons.min.css"));

            bundles.Add(new ScriptBundle("~/js/main-js").Include(
                        "~/assets/js/vendor.min.js",
                        "~/assets/js/app.min.js"));



            bundles.Add(new StyleBundle("~/css/datatables-css").Include(
                     "~/assets/libs/datatables.net-bs4/css/dataTables.bootstrap4.min.css",
                     "~/assets/libs/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css",
                     "~/assets/libs/datatables.net-buttons-bs4/css/buttons.bootstrap4.min.css",
                     "~/assets/libs/datatables.net-select-bs4/css//select.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/js/datatables-js").Include(
                        "~/assets/libs/datatables.net/js/jquery.dataTables.min.js",
                        "~/assets/libs/datatables.net-bs4/js/dataTables.bootstrap4.min.js",
                        "~/assets/libs/datatables.net-responsive/js/dataTables.responsive.min.js",
                        "~/assets/libs/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js",
                        "~/assets/libs/datatables.net-buttons/js/dataTables.buttons.min.js",
                        "~/assets/libs/datatables.net-buttons-bs4/js/buttons.bootstrap4.min.js",
                        "~/assets/libs/datatables.net-buttons/js/buttons.html5.min.js",
                        "~/assets/libs/datatables.net-buttons/js/buttons.flash.min.js",
                        "~/assets/libs/datatables.net-buttons/js/buttons.print.min.js",
                        "~/assets/libs/datatables.net-keytable/js/dataTables.keyTable.min.js",
                        "~/assets/libs/datatables.net-select/js/dataTables.select.min.js",
                        "~/assets/libs/pdfmake/build/pdfmake.min.js",
                        "~/assets/libs/pdfmake/build/vfs_fonts.js",
                        "~/assets/js/pages/datatables.init.js"));


        }
    }
}