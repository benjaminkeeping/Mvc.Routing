using Machine.Specifications;

namespace Mvc.Routing.Specs
{
    [Behaviors]
    public class should_have_the_expected_http_method : attribute_context
    {
        It should_set_the_http_method_as_delete = () => theAttribute.HttpMethod.ShouldEqual(theExpectedHttpMethod);        
    }
}