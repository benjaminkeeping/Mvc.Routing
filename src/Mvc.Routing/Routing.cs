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
        public static void Register(Assembly controllerAssembly)
        {
            Register(new [] { controllerAssembly});
        }

        public static void Register(Assembly[] controllerAssemblies)
        {
            foreach (var route in GetControllersThatWantRouting(controllerAssemblies).Select(GetRouteInfoFor).SelectMany(routeInfo => routeInfo))
            {
                if (RouteTable.Routes[route.GetRouteName()] == null)
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
                routeInfo.AddRange(from customAttribute in customAttributes where IsOurAttribute(customAttribute) select new RouteInfo(controllerType, methodInfo.Name, GetRouteFrom(customAttribute)));
            }
            return routeInfo;
        }

        static string GetRouteFrom(object customAttribute)
        {
            var attr = (customAttribute as BaseRouteAttribute);
            if (attr != null)
            {
                return attr.Route;
            }  
            if (customAttribute.GetType() == typeof(RouteAttribute))
            {
                return (customAttribute as RouteAttribute).Route;
            }
            throw new ArgumentException(string.Format("Type {0} is not one of our types", customAttribute.GetType()));
        }

        static bool IsOurAttribute(object customAttribute)
        {
            var attr = (customAttribute as BaseRouteAttribute);
            if (attr != null)
            {
                return true;
            }
            return customAttribute.GetType() == typeof(RouteAttribute);
        }
    }
}