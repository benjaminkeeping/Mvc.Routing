using System;

namespace Mvc.Routing
{
    internal static class RouteInfoFactory

    {
        public static RouteInfo CreateFrom(Type controllerType, string name, object customAttribute)
        {
            var attr = (customAttribute as BaseRouteAttribute);
            if (attr != null)
            {
                return new RouteInfo(controllerType, name, attr.Route, attr.Description);
            }
            if (customAttribute.GetType() == typeof(RouteAttribute))
            {
                var rattr = (customAttribute as RouteAttribute);
                return new RouteInfo(controllerType, name, rattr.Route, "");
            }
            throw new ArgumentException(String.Format("Type {0} is not one of our types", customAttribute.GetType()));

        }


    }
}