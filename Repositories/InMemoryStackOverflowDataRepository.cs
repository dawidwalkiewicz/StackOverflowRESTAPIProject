using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowDataRepository : IStackOverflowDataRepository
    {
        private static readonly ISet<StackOverflowData> _data = new HashSet<StackOverflowData>();

        public async Task<IEnumerable<StackOverflowData>> GetAllDataAsync()
            => await Task.FromResult(_data);
    }
}