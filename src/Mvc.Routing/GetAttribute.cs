using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class GetAttribute : ActionMethodSelectorAttribute
    {
        readonly string _route;

        public GetAttribute(string route)
        {
            _route = route;
        }

        public string Route
        {
            get { return _route; }
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext.RequestContext.HttpContext.Request.HttpMethod.ToLower() == "get") return true;
            return false;
        }
    }
}
