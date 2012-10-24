using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class PutAttribute : BaseRouteAttribute
    {
        public PutAttribute(string route)
            : base(route, "", "put")
        {
        }

        public PutAttribute(string route, string description)
            : base(route, description, "get")
        {
        }
    }
}