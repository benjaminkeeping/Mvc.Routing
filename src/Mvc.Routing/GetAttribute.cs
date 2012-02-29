using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class GetAttribute : BaseRouteAttribute
    {
        public GetAttribute(string route)
            : base(route, "get")
        {
        }

    }
}
