using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowDataRepository
    {
        Task<StackOverflowData> GetDataAsync(StackOverflowData data);
        Task<IEnumerable<StackOverflowData>> GetAllDataAsync();
    }
}