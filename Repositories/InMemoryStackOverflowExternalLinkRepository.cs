using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowExternalLinkRepository : IStackOverflowExternalLinkRepository
    {
        private static readonly ISet<StackOverflowExternalLink> _externalLinks = new HashSet<StackOverflowExternalLink>();

        public async Task<IEnumerable<StackOverflowExternalLink>> GetAllExternalLinksAsync()
            => await Task.FromResult(_externalLinks);
    }
}