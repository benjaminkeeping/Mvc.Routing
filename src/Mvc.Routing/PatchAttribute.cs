using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class PatchAttribute : ActionMethodSelectorAttribute
    {
        readonly string _route;

        public PatchAttribute(string route)
        {
            _route = route;
        }

        public string Route
        {
            get { return _route; }
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext.RequestContext.HttpContext.Request.HttpMethod.ToLower() == "patch") return true;
            return false;
        }
    }
}