using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrdersApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Start",
                url: "start",
                defaults: new { controller = "Orders", action = "Index" }
            );
            routes.MapRoute(
                name: "ProcessOrders",
                url: "processOrders",
                defaults: new { controller = "Orders", action = "ProcessOrders" }
            );

            routes.MapRoute(
                name: "Orders",
                url: "orders",
                defaults: new { controller = "Orders", action = "Orders"}
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
