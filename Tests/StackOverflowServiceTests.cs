using StackOverflowRESTAPIProject.Services;
using Xunit;

namespace StackOverflowRESTAPIProject.Tests
{
    public class StackOverflowServiceTests
    {
        [Fact]
        public void Get_method_should_return_tags_data_from_stackoverflow()
        {
            var accessToken = Guid.NewGuid().ToString();
            var accessTokenSecret = Guid.NewGuid().ToString();
            var stackOverflowService = new StackOverflowService(accessToken, accessTokenSecret);
            stackOverflowService.GetTags();
        }
    }
}