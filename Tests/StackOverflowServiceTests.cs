using StackOverflowRESTAPIProject.Services;
using Xunit;

namespace StackOverflowRESTAPIProject.Tests
{
    public class StackOverflowServiceTests
    {
        [Fact]
        public void Get_method_should_return_tags_data_from_stackoverflow()
        {
            var stackOverflowService = new StackOverflowService();
            stackOverflowService.GetTags();
        }
    }
}