using System;

namespace Mvc.Routing
{
    public class RouteInfo
    {
        readonly string _actionName;
        readonly string _route;
        private readonly string _description;
        readonly string _controllerName;

        public RouteInfo(Type controllerType, string actionName, string route, string description)
        {
            _actionName = actionName;
            _route = route;
            _description = description;
            _controllerName = controllerType.Name.Replace("Controller", "");
        }

        public string Description
        {
            get { return _description; }
        }

        public string ControllerName
        {
            get { return _controllerName; }
        }

        public string Route
        {
            get { return _route; }
        }

        public string ActionName
        {
            get { return _actionName; }
        }

        public string GetRouteName()
        {
            return string.Format("{0} {1}", ControllerName, ActionName);
        }


    }
}