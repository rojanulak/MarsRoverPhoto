using System.Web.Http;
using System.Web.Http.Cors;
using MarsRover.Data.Mapper;
using Swashbuckle.Application;

namespace MarsRover.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutoMapperConfig.Initialize();
            var cors = new EnableCorsAttribute("*", "*", "*"); //TODO NEED to revist this

            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
