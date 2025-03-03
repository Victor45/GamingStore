using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GamingTech.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bootstrap css
            bundles.Add(new StyleBundle("~/bundle/bootstrap/css").Include(
                "~/content/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            //font awesome
            bundles.Add(new StyleBundle("~/bundle/font-awesome/css").Include(
                "~/content/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            //nouislider
            bundles.Add(new StyleBundle("~/bundle/nouislider/css").Include(
                "~/content/css/nouislider.min.css", new CssRewriteUrlTransform()));

            //slick-theme
            bundles.Add(new StyleBundle("~/bundle/slick-theme/css").Include(
                "~/content/css/slick-theme.css", new CssRewriteUrlTransform()));

            //slick
            bundles.Add(new StyleBundle("~/bundle/slick/css").Include(
                "~/content/css/slick.css", new CssRewriteUrlTransform()));

            //style
            bundles.Add(new StyleBundle("~/bundle/style/css").Include(
                "~/content/css/style.css", new CssRewriteUrlTransform()));

            //bootstrap js
            bundles.Add(new ScriptBundle("~/bundle/bootstrap/js").Include(
                "~/content/js/bootstrap.min.js"));

            //jquery js
            bundles.Add(new ScriptBundle("~/bundle/jquery/js").Include(
                "~/content/js/jquery.min.js"));

            //jquery.zoom js
            bundles.Add(new ScriptBundle("~/bundle/jqueryzoom/js").Include(
                "~/content/js/jquery-zoom.min.js"));

            //main js
            bundles.Add(new ScriptBundle("~/bundle/main/js").Include(
                "~/content/js/main.js"));

            //nouislider js
            bundles.Add(new ScriptBundle("~/bundle/nouislider/js").Include(
                "~/content/js/nouislider.min.js"));

            //slick js
            bundles.Add(new ScriptBundle("~/bundle/slick/js").Include(
                "~/content/js/slick.min.js"));
        }
    }
}