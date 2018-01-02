using System.Web.Mvc;
using System.Web.Routing;

namespace Tamagotchi.Views.Shared.Helpers
{
    public static class NavigationHelpers
    {
        public static string ActiveClass(this HtmlHelper helper, string controllerName, string actionName)
        {
            RouteData routeData = helper.ViewContext.RouteData;

            string routeController = routeData.Values["controller"] as string;
            string routeAction = routeData.Values["action"] as string;

            return controllerName == routeController && actionName == routeAction ? "active" : "";
        }
    }
}