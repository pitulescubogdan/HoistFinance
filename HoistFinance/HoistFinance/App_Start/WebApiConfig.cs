using System.Web.Http;

namespace HoistFinance
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "InsertData",
               routeTemplate: "api/data",
               defaults: new { controller="Requests"}
           );

            config.Routes.MapHttpRoute(
               name: "GetRequests",
               routeTemplate: "api/jobs/saveFiles",
               defaults: new { controller = "Requests",  action= "SaveFiles" }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }
    }
}
