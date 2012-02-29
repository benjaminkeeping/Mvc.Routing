using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class DeleteAttribute : ActionMethodSelectorAttribute
    {
        readonly string _route;

        public DeleteAttribute(string route)
        {
            _route = route;
        }

        public string Route
        {
            get { return _route; }
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext.RequestContext.HttpContext.Request.HttpMethod.ToLower() == "delete") return true;
            return false;
        }
    }
}