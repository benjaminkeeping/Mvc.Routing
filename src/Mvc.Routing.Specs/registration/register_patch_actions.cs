using System.Linq;
using System.Web.Routing;
using Machine.Specifications;

namespace Mvc.Routing.Specs.patch
{
    [Subject(typeof(GetAttribute), "Given a controller action marked as Patch")]
    public class when_registering_routes : register_route_context
    {
        Establish context = () =>
        {
            theExpectedRouteUrl = "test/patch/route";
            theExpectedActionName = "PatchAction";
            theExpectedControllerName = "Test";
        };

        Because of = () =>
        {
            Routing.Register(typeof(TestController).Assembly);
            theRoute =
                RouteTable.Routes.Select(x => x as Route).Where(x => x.Url == theExpectedRouteUrl).FirstOrDefault();
        };

        Behaves_like<route_should_be_registered> route_should_be_registered;
    }
}