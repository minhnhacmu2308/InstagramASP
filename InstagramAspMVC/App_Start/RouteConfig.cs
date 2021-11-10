using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InstagramAspMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "profile",
               url: "User/Profile/{email}/{id}",
               defaults: new { controller = "User", action = "Profile", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "list follower",
              url: "User/Follower/{id}",
              defaults: new { controller = "User", action = "ListFollower", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "list following",
             url: "User/Following/{id}",
             defaults: new { controller = "User", action = "ListFollowing", id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
