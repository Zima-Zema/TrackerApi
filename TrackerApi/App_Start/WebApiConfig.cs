﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace TrackerApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnableCors();
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithAction",
            //    routeTemplate: "api/{controller}/{action}/{email:alpha}",
            //    defaults: new { email = RouteParameter.Optional });
        }
    }
}
