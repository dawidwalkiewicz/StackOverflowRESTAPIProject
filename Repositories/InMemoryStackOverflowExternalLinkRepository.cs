using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Repositories
{
    public class InMemoryStackOverflowExternalLinkRepository : IStackOverflowExternalLinkRepository
    {
        private static ISet<StackOverflowExternalLink> _externalLinks = new HashSet<StackOverflowExternalLink>();

        public async Task<StackOverflowExternalLink> GetExternalLinkAsync(StackOverflowExternalLink externalLink)
            => await Task.FromResult(_externalLinks.Single(x => x.ExternalLinkUrl == externalLink.ExternalLinkUrl));

        public async Task<IEnumerable<StackOverflowExternalLink>> GetAllExternalLinksAsync()
            => await Task.FromResult(_externalLinks);
    }
}