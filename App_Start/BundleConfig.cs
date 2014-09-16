using System.Web;
using System.Web.Optimization;

namespace MvcDemoRestorent
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                             "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
          

            bundles.Add(new ScriptBundle("~/bundles/Myjquery").Include(
                        "~/Scripts/JsDatePicker.js",
                        "~/Scripts/bootstrap-alert.js",
                        "~/Scripts/bootstrap-button.js",
                        "~/Scripts/bootstrap-carousel.js",
                        "~/Scripts/bootstrap-collapse.js",
                        "~/Scripts/bootstrap-dropdown.js",
                        "~/Scripts/bootstrap-modal.js",
                        "~/Scripts/bootstrap-popover.js",
                        "~/Scripts/bootstrap-scrollspy.js",
                        "~/Scripts/bootstrap-tab.js",
                        "~/Scripts/bootstrap-toggle.js",
                        "~/Scripts/bootstrap-tooltip.js",
                        "~/Scripts/bootstrap-tour.js",
                        "~/Scripts/bootstrap-transition.js",
                        "~/Scripts/bootstrap-typeahead.js",
                        "~/Scripts/charisma.js",
                        "~/Scripts/excanvas.js",
                        "~/Scripts/fullcalendar.min.js",
                        "~/Scripts/jquery-1.7.2.min.js",
                        "~/Scripts/jquery-ui-1.8.21.custom.min.js",
                        "~/Scripts/jquery.autogrow-textarea.js",
                        "~/Scripts/jquery.chosen.min.js",
                        "~/Scripts/jquery.cleditor.min.js",
                        "~/Scripts/jquery.colorbox.min.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/jquery.elfinder.min.js",
                        "~/Scripts/jquery.flot.min.js",
                        "~/Scripts/jquery.flot.pie.min.js",
                        "~/Scripts/jquery.flot.resize.min.js",
                        "~/Scripts/jquery.flot.stack.js",
                        "~/Scripts/jquery.history.js",
                        "~/Scripts/jquery.iphone.toggle.js",
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery.noty.js",
                        "~/Scripts/jquery.raty.min.js",
                        "~/Scripts/jquery.uniform.min.js",
                        "~/Scripts/jquery.uploadify-3.1.min.js"


                        ));

             //Use the development version of Modernizr to develop with and learn from. Then, when you're
             //ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/bootstrap-cerulean.css",
                        "~/Content/css/bootstrap-classic.css",
                        "~/Content/css/bootstrap-classic.min.css",
                        "~/Content/css/bootstrap-cyborg.css",
                        "~/Content/css/bootstrap-journal.css",
                        "~/Content/css/bootstrap-responsive.css",
                        "~/Content/css/bootstrap-responsive.min.css",
                        "~/Content/css/bootstrap-simplex.css",
                        "~/Content/css/bootstrap-slate.css",
                        "~/Content/css/bootstrap-spacelab.css",
                        "~/Content/css/bootstrap-united.css",
                        "~/Content/css/charisma-app.css",
                        "~/Content/css/chosen.css",
                        "~/Content/css/colorbox.css",
                        "~/Content/css/elfinder.min.css",
                        "~/Content/css/elfinder.theme.css",
                        "~/Content/css/fullcalendar.css",
                        "~/Content/css/fullcalendar.print.css",
                        "~/Content/css/jquery-ui-1.8.21.custom.css",
                        "~/Content/css/jquery.cleditor.css",
                        "~/Content/css/jquery.iphone.toggle.css",
                        "~/Content/css/jquery.noty.css",
                        "~/Content/css/noty_theme_default.css",
                        "~/Content/css/opa-icons.css",
                        "~/Content/css/uniform.default.css",
                        "~/Content/css/uploadify.css"));

        

            



        }
    }
}