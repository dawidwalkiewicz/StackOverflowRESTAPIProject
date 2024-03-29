using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowCollectiveRepository
    {
        Task<IEnumerable<StackOverflowCollective>> GetAllCollectivesAsync();
    }
}