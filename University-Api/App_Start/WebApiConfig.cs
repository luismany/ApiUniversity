﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace University_Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Configuración y servicios de API web

            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
