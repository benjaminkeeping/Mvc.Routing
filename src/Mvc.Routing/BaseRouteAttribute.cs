using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class BaseRouteAttribute : ActionMethodSelectorAttribute
    {
        readonly string _route;
        private readonly string _description;
        readonly string _httpMethod;

        protected BaseRouteAttribute(string route)
        {
            _route = route;
        }

        protected BaseRouteAttribute(string route, string description, string httpMethod)
        {
            _route = route;
            _description = description;
            _httpMethod = httpMethod;
        }


        public string Description
        {
            get { return _description; }
        }

        public string HttpMethod
        {
            get { return _httpMethod; }
        }

        public string Route
        {
            get { return _route; }
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.HttpMethod.ToLower() == _httpMethod.ToLower();
        }
    }
}