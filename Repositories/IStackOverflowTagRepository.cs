using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowTagRepository
    {
        Task<StackOverflowTag> GetTagAsync(StackOverflowTag tag);
        Task<IEnumerable<StackOverflowTag>> GetAllTagsAsync();
    }
}