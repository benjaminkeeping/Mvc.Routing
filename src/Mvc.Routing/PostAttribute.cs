using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class PostAttribute : BaseRouteAttribute
    {
        public PostAttribute(string route)
            : base(route, "", "post")
        {
        }

        public PostAttribute(string route, string description)
            : base(route, description, "get")
        {
        }
    }
}