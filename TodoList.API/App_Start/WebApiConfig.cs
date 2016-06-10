using System.Web.Http;
using TodoList.API.Controllers;

namespace TodoList.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // This is because we want to support Dependency Injection in our controller
            config.DependencyResolver = new ResolveController();
        }
    }
}
