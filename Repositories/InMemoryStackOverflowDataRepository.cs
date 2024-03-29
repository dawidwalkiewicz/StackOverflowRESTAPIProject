using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowDataRepository : IStackOverflowDataRepository
    {
        private static ISet<StackOverflowData> _data = new HashSet<StackOverflowData>();

        public async Task<StackOverflowData> GetDataAsync(StackOverflowData data)
            => await Task.FromResult(_data.Single(x => x.Tag == data.Tag));

        public async Task<IEnumerable<StackOverflowData>> GetAllDataAsync()
            => await Task.FromResult(_data);
    }
}