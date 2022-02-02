using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Diplom
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    null,
            //    "",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional, page = 1 }
            //    );

            routes.MapRoute(
                name: "ShopCategory",
                url: "Shop/{category}",
                new { controller = "Shop", action = "Index", page = 1 }
                );

            routes.MapRoute(
                name: "TypeCategory",
                url: "Page_{page}/{category}/{genre}",
                new { controller = "Shop", action = "Index", page = 1 }
                );

            routes.MapRoute(
                name: "opa",
                url: "Page_{page}",
                defaults: new { controller = "Shop", action = "Index", genre = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: null,
                url: "Page_{page}/{genre}",
                new { controller = "Shop", action = "Index", page = 1 }
                );

            routes.MapRoute(
                name: "Shoproute",
                url: "Shop/{genre}",
                new { controller = "Shop", action = "Index", page = 1 }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                null,
                "{controller}/{action}"
                );
        }
    }
}
