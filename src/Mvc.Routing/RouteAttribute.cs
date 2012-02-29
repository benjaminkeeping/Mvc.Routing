using System;
using System.Collections.Generic;
using System.Text;

namespace Mvc.Routing
{
    public class RouteAttribute : Attribute
    {
        readonly string _route;

        public RouteAttribute(string route)
        {
            _route = route;
        }

        public string Route
        {
            get { return _route; }
        }
    }
}
