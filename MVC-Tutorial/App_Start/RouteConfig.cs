using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTutorial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This means to ignore weird routes which "may" expose the Web App.
            // REGEX is enforced
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // Default Fallback Route (Basic Routing)
            // Parameters:
            //     name: - This means the name of the Route, HAS TO BE UNIQUE. "Default" will be used on Error.
            //     url: - The URL that it needs to be mapped and matched, ALL URL will pass this. {id} means a basic 1 param pass, we'll go through this in Controller section.
            //     defaults - The controller for the Route (An explicit object has to be passed.)
            // ----------
            // routes.MapRoute(
            //     name: "Default",
            //     url: "{controller}/{action}/{id}",
            //     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            // );
            // ----------
            
            // Default Fallback Route (Basic Routing with Route Constraints)
            // Route constraints mean Type Casting and filtering a URL with specific type of input you want with REGEX.
            // NOTE: If you add ? behind your constraint, it means the valid can be there or not be there. Tentative param.
            // "\\d{2}" means I only want 2 numbers or characters for the ID. "\\d" is just a convention for REGEX.
            // You can view all of them here: https://www.tektutorialshub.com/asp-net-core/asp-net-core-route-constraints/
            // ----------
            // routes.MapRoute(
            //     name: "Default",
            //     url: "{controller}/{action}/{id:int?}",
            //     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //     constraints: new { id = "\\d{2}"}
            // );
            // ----------
            
            // Advanced Routing
            // With only this line, it gets the [Route()] typecasting and uses that as the Route. This is the power of a MVC.
            routes.MapMvcAttributeRoutes();
        }
    }
}
