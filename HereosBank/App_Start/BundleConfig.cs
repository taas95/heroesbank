using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HereosBank.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            
         

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Custom bundles for public/visitors end
            //CSS
            bundles.Add(new StyleBundle("~/Content/loginView").Include(
                "~/Content/CustomElements/css/main.css",
                "~/Content/CustomElements/css/util.css",
                "~/Content/bootstrap.css",
                "~/Content/CustomElements/vendor/animate/animate.css",
                "~/Content/CustomElements/vendor/css-hamburgers/hamburgers.min.css",
                 //"~/Content/CustomElements/vendor/select2/select2.min.css",
                 "~/Content/CustomElements/vendor/select2/select2.min.css"
                ));

            //JS
            bundles.Add(new ScriptBundle("~/bundles/loginJS").Include(
                "~/Scripts/CustomScripts/js/main.js",
                "~/Scripts/CustomScripts/js/select2.min.js",
                "~/Scripts/CustomScripts/tilt/tilt.jquery.min.js",
                "~/Scripts/bootstrap.js",
                "~/Content/CustomElements/vendor/bootstrap/js/bootstrap.js",
                "~/Content/CustomElements/vendor/bootstrap/js/popper.js"
                ));

        }
    }
}