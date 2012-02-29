using System.Linq;
using System.Web.Routing;
using Machine.Specifications;

namespace Mvc.Routing.Specs.post
{
    [Subject(typeof(GetAttribute), "Given a controller action marked as Post")]
    public class when_registering_routes : register_route_context
    {
        Establish context = () =>
        {
            theExpectedRouteUrl = "test/post/route";
            theExpectedActionName = "PostAction";
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