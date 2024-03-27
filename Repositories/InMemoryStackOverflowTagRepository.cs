using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowTagRepository : IStackOverflowTagRepository
    {
        private static ISet<StackOverflowTag> _tags = new HashSet<StackOverflowTag>();

        public async Task<StackOverflowTag> GetTagAsync(StackOverflowTag tag)
            => await Task.FromResult(_tags.Single(x => x.TagName == tag.TagName));

        public async Task<IEnumerable<StackOverflowTag>> GetAllTagsAsync()
            => await Task.FromResult(_tags);
    }
}