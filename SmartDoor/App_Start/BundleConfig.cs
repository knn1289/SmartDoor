using System.Web;
using System.Web.Optimization;

namespace SmartDoor
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* ------------------------JAVASCRIPT BUNDLE CONFIG----------------------------------------------- */
            // Place all your JavaScript configuration in this section)

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/select2.js",
                      "~/Scripts/Vivicare.js",
                      "~/Scripts/respond.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/DataTables-1.9.4/media/js/jquery.js",
                "~/Scripts/DataTables-1.9.4/media/js/jquery.dataTables.js",
                "~/Scripts/dataTables.fixedHeader.js"));

            bundles.Add(new ScriptBundle("~/bundles/fileupload").Include(
    "~/Scripts/bootstrap-fileupload.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                "~/Scripts/fullcalendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-timepicker").Include(
                "~/Scripts/bootstrap-timepicker.js"));


            /* ------------------------STYLE SHEET BUNDLE CONFIG----------------------------------------------- */
            // Place all your Stylesheet in this section.)

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/select2.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/font-awesome.css",
                      "~/Content/DataTables-1.9.4/media/css/jquery.dataTables.css"));

            bundles.Add(new StyleBundle("~/Content/fileupload").Include(
                      "~/Content/bootstrap-fileupload.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                "~/Content/jquery.dataTables.css"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                      "~/Content/fullcalendar.css"));

            bundles.Add(new ScriptBundle("~/Content/bootstrap-timepicker").Include(
                    "~/Content/bootstrap-timepicker.css"));

        }

    } // class
} // namespace