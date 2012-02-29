using System.Linq;
using System.Web.Routing;
using Machine.Specifications;

namespace Mvc.Routing.Specs.put
{
    [Subject(typeof(GetAttribute), "Given a controller action marked as Get")]
    public class when_registering_routes : register_route_context
    {
        Establish context = () =>
        {
            theExpectedRouteUrl = "test/put/route";
            theExpectedActionName = "PutAction";
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