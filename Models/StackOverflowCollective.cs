namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowCollective
    {
        public StackOverflowTag StackOverflowTags { get; set; }
        public StackOverflowExternalLink StackOverflowExternalLinks { get; set; }
        public string CollectiveDescription { get; set; }
        public string CollectiveLinkUrl { get; set; }
        public string CollectiveName { get; set; }
        public string CollectiveSlug { get; set; }

        public StackOverflowCollective(StackOverflowTag stackOverflowTags, StackOverflowExternalLink stackOverflowExternalLinks, string collectiveDescription, string collectiveLinkUrl, string collectiveName, string collectiveSlug)
        {
            StackOverflowTags.TagName = stackOverflowTags.TagName;
            StackOverflowExternalLinks = stackOverflowExternalLinks;
            CollectiveDescription = collectiveDescription;
            CollectiveLinkUrl = collectiveLinkUrl;
            CollectiveName = collectiveName;
            CollectiveSlug = collectiveSlug;
        }
    }
}