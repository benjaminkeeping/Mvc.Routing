using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Routing.Specs
{
    public class register_route_context
    {
        protected static Route theRoute;
        protected static string theExpectedRouteUrl;
        protected static string theExpectedActionName;
        protected static string theExpectedControllerName;
    }

    public class TestController : Controller
    {
        [Get("test/get/route")]
        public ActionResult GetAction()
        {
            return new EmptyResult();
        }

        [Post("test/post/route")]
        public ActionResult PostAction(string a, int b, Guid c)
        {
            return new EmptyResult();
        }

        [Put("test/put/route")]
        public ActionResult PutAction(int a, string b)
        {
            return new EmptyResult();
        }

        [Delete("test/delete/route")]
        public ActionResult DeleteAction(long a)
        {
            return new EmptyResult();
        }

        [Patch("test/patch/route")]
        public ActionResult PatchAction(long a)
        {
            return new EmptyResult();
        }

        [Route("test/plain/route")]
        public ActionResult PlainAction(long a)
        {
            return new EmptyResult();
        }
    }
}