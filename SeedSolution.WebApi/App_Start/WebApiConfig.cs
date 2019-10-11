using SeedSolution.WebApi.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SeedSolution.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.EnableCors(new EnableCorsAttribute("*"
                , "*"
                , "GET,PUT,POST,DELETE,OPTIONS"));
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //config.EnableCors();

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new CustomResponseHandler());
        }
    }
}
