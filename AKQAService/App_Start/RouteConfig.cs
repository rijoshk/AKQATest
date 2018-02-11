using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AKQAService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "API Default",
                url: "api/{controller}/{action}/{amount}",
                defaults: new { controller = "AKQAService", action = "ConvertAmount", amount = UrlParameter.Optional }
            );
        }
    }
}