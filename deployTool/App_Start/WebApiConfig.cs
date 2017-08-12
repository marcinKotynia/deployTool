using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace deployTool
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Main",
                routeTemplate: "",
                defaults: new { id = RouteParameter.Optional, controller = "main" });


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "git/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
