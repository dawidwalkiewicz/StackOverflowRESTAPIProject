using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowCollectiveRepository : IStackOverflowCollectiveRepository
    {
        private static ISet<StackOverflowCollective> _collectives = new HashSet<StackOverflowCollective>();

        public async Task<StackOverflowCollective> GetCollectiveAsync(StackOverflowCollective collective)
            => await Task.FromResult(_collectives.Single(x => x.CollectiveName == collective.CollectiveName));

        public async Task<IEnumerable<StackOverflowCollective>> GetAllCollectivesAsync()
            => await Task.FromResult(_collectives);
    }
}