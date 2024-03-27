using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowCollectiveRepository
    {
        Task<StackOverflowCollective> GetCollectiveAsync(StackOverflowCollective collective);
        Task<IEnumerable<StackOverflowCollective>> GetAllCollectivesAsync();
    }
}