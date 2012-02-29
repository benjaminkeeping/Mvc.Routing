using System.Reflection;
using System.Web.Mvc;

namespace Mvc.Routing
{
    public class DeleteAttribute : BaseRouteAttribute
    {
        public DeleteAttribute(string route)
            : base(route, "delete")
        {
        }
    }
}