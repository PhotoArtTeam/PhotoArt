using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace PhotoArt.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

<<<<<<< HEAD
            bundles.Add(new ScriptBundle("~/bundles/Site").Include(
                     "~/Scripts/jquery.min.js",
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/Libs/bootstrap-material-design/dist/js/ripples.min.js",
                     "~/Scripts/Libs/bootstrap-material-design/dist/js/material.min.js",
                     "~/Scripts/appStart.js"));

            bundles.Add(new ScriptBundle("~/bundles/Admin").Include(
                "~/Scripts/Admin/app.js",
                "~/Scripts/Admin/dashboard.js"));
=======
            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                "~/Scripts/material.min.js",
                "~/Scripts/ripples.min.js"));
>>>>>>> 654bc131319dc3d6f2c7b591db3204b97c533735

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });
        }
    }
}