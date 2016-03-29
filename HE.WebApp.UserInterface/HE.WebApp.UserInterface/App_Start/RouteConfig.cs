using HE.WebApp.UserInterface.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace HE.WebApp.UserInterface
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ORIGINAL - commentted out because I added more logic for choosing which screen to show when user logs in
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Account", action = "Signin", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Initialization", id = UrlParameter.Optional }
            );
        }
    }
}
