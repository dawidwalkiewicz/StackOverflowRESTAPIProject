using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowExternalLinkRepository
    {
        Task<StackOverflowExternalLink> GetExternalLinkAsync(StackOverflowExternalLink externalLink);
        Task<IEnumerable<StackOverflowExternalLink>> GetAllExternalLinksAsync();
    }
}