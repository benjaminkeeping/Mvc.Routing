namespace Mvc.Routing
{
    public class PatchAttribute : BaseRouteAttribute
    {
        public PatchAttribute(string route) : base(route, "", "patch")
        {
        }

        public PatchAttribute(string route, string description)
            : base(route, description, "get")
        {
        }
    }
}