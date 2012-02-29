using Machine.Specifications;

namespace Mvc.Routing.Specs
{
    [Behaviors]
    public class route_should_be_registered : register_route_context
    {
        It should_register_the_route = () => theRoute.Url.ShouldNotBeNull();
        It should_register_the_route_with_the_action = () => theRoute.Defaults["action"].ShouldEqual(theExpectedActionName);
        It should_register_the_route_with_the_controller = () => theRoute.Defaults["controller"].ShouldEqual(theExpectedControllerName);
    }
}