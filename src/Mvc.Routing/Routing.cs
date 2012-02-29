using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Routing
{
    public static class Routing
    {
        public static void Register(Assembly[] controllerAssemblies)
        {
            foreach (var route in GetControllersThatWantRouting(controllerAssemblies).Select(GetRouteInfoFor).SelectMany(routeInfo => routeInfo))
            {
                RouteTable.Routes.MapRoute(route.GetRouteName(), route.Route,
                                           new {controller = route.ControllerName, action = route.ActionName});
            }
        }

        static IEnumerable<Type> GetControllersThatWantRouting(IEnumerable<Assembly> controllerAssemblies)
        {
            return controllerAssemblies.SelectMany(a => a.GetTypes().Where(x => typeof(Controller).IsAssignableFrom(x)));
        }

        static IEnumerable<RouteInfo> GetRouteInfoFor(Type controllerType)
        {
            var routeInfo = new List<RouteInfo>();
            var methods = controllerType.GetMethods();
            foreach (var methodInfo in methods)
            {
                var customAttributes = methodInfo.GetCustomAttributes(true);
                routeInfo.AddRange(from customAttribute in customAttributes where customAttribute.GetType() == typeof(RouteAttribute) select new RouteInfo(controllerType, methodInfo.Name, (customAttribute as RouteAttribute).Route));
            }
            return routeInfo;
        }
    }
}