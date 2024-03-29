using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowTagRepository
    {
        Task<IEnumerable<StackOverflowTag>> GetAllTagsAsync();
    }
}