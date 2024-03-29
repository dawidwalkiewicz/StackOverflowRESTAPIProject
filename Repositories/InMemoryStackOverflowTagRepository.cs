using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowTagRepository : IStackOverflowTagRepository
    {
        private static readonly ISet<StackOverflowTag> _tags = new HashSet<StackOverflowTag>();

        public async Task<IEnumerable<StackOverflowTag>> GetAllTagsAsync()
            => await Task.FromResult(_tags);
    }
}