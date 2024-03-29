using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowCollectiveRepository : IStackOverflowCollectiveRepository
    {
        private static readonly ISet<StackOverflowCollective> _collectives = new HashSet<StackOverflowCollective>();

        public async Task<IEnumerable<StackOverflowCollective>> GetAllCollectivesAsync()
            => await Task.FromResult(_collectives);
    }
}