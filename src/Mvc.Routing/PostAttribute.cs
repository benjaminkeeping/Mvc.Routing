using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class PostAttribute : ActionMethodSelectorAttribute
    {
        readonly string _route;

        public PostAttribute(string route)
        {
            _route = route;
        }

        public string Route
        {
            get { return _route; }
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext.RequestContext.HttpContext.Request.HttpMethod.ToLower() == "post") return true;
            return false;
        }
    }
}