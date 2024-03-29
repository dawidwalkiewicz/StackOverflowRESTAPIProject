using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowExternalLinkRepository
    {
        Task<IEnumerable<StackOverflowExternalLink>> GetAllExternalLinksAsync();
    }
}