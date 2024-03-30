namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowCollective
    {
        public List<StackOverflowTag> StackOverflowTags { get; set; }
        public List<StackOverflowExternalLink> StackOverflowExternalLinks { get; set; }
        public string CollectiveDescription { get; set; }
        public string CollectiveLinkUrl { get; set; }
        public string CollectiveName { get; set; }
        public string CollectiveSlug { get; set; }

        public StackOverflowCollective(List<StackOverflowTag> stackOverflowTags, List<StackOverflowExternalLink> stackOverflowExternalLinks,
            string collectiveDescription, string collectiveLinkUrl, string collectiveName, string collectiveSlug)
        {
            StackOverflowTags = stackOverflowTags;
            StackOverflowExternalLinks = stackOverflowExternalLinks;
            CollectiveDescription = collectiveDescription;
            CollectiveLinkUrl = collectiveLinkUrl;
            CollectiveName = collectiveName;
            CollectiveSlug = collectiveSlug;
        }
    }
}