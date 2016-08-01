using System.Web.Optimization;

namespace IFK.Server
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/Content/Scripts/lib/jquery.js")
                .Include("~/Content/Scripts/lib/materialize.js")
                .Include("~/Content/Scripts/lib/styleHelper.js")
                .Include("~/Content/Scripts/lib/angular.min.js")
                .Include("~/Content/Scripts/lib/angular-route.min.js")
                .Include("~/Content/Scripts/Build/App.js"));

            bundles.Add(new StyleBundle("~/styles")
               .Include("~/Content/Styles/materialize.css", new CssRewriteUrlTransform())
               .Include("~/Content/Styles/size.css")
               .Include("~/Content/Styles/textColor.css")
               .Include("~/Content/Styles/input.css")
               .Include("~/Content/Styles/chat.css")
               .Include("~/Content/Styles/issue.css")
               .Include("~/Content/Styles/user.css"));
               
        }
    }
}
