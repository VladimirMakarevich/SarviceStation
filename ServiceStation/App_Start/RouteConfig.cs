using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceStation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Order",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Order", action = "New_Order", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Logout",
                url: "Logout",
                defaults: new { controller = "Login", action = "Logout" }
            );
        }
    }
}
