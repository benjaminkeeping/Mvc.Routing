namespace Mvc.Routing
{
    public class PatchAttribute : BaseRouteAttribute
    {
        public PatchAttribute(string route) : base(route, "patch")
        {
        }
    }
}