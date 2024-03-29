using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowDataRepository
    {
        Task<IEnumerable<StackOverflowData>> GetAllDataAsync();
    }
}