using System.Linq;
using System.Web.Routing;
using Machine.Specifications;

namespace Mvc.Routing.Specs.plain
{
    [Subject(typeof(GetAttribute), "Given a controller action marked as a Route")]
    public class when_registering_routes : register_route_context
    {
        Establish context = () =>
        {
            theExpectedRouteUrl = "test/plain/route";
            theExpectedActionName = "PlainAction";
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