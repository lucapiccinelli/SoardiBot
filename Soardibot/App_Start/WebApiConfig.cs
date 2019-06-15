using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Soardibot.Dto;
using WebApiContrib.Formatting.Jsonp;
using IContainer = System.ComponentModel.IContainer;

namespace Soardibot
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}/{ext}",
                defaults: new { id = RouteParameter.Optional, ext = "json" }
            );

            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/xml");

            var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);

            jsonpFormatter.AddUriPathExtensionMapping("jsonp", "text/javascript");
        }

        public static void RegisterSecrets(HttpConfiguration config, Secrets secrets)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterInstance(secrets);
            //builder.RegisterType<Secrets>().As<IHeyExceptionHandler>().InstancePerRequest();
            //builder.RegisterType<HangfireJobRepository>().As<IJobRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<HeyService>().As<IHeyService>().InstancePerLifetimeScope();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
