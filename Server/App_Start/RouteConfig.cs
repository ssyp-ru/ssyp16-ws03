using System.Web.Mvc;
using System.Web.Routing;

namespace IFK.Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Root",
                url: "Partial/{name}",
                defaults: new { controller = "Home", action = "Partial"}
            );

            routes.MapRoute(
                name: "PartialFromFolder",
                url: "Partial/{folder}/{name}",
                defaults: new { controller = "Home", action = "PartialFromFolder" }
            );

            routes.MapRoute(
                name: "Api",
                url: "api/{controller}/{action}"
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
