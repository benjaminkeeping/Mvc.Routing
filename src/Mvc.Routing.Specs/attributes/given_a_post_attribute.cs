using Machine.Specifications;

namespace Mvc.Routing.Specs
{
    [Subject(typeof(PostAttribute))]
    public class given_a_post_attribute : attribute_context
    {
        Establish context = () =>
        {
            theExpectedHttpMethod = "post";
            theAttribute = new PostAttribute("a route");
        };

        Behaves_like<should_have_the_expected_http_method> should_have_the_expected_http_method;
    }
}