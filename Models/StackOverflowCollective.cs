namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowCollective
    {
        public StackOverflowTag StackOverflowTags { get; set; }
        public StackOverflowExternalLink StackOverflowExternalLinks { get; set; }
        public string CollectiveDescription { get; set; }
        public string LinkUrl { get; set; }
        public string CollectiveName { get; set; }
        public string CollectiveSlug { get; set; }

        protected StackOverflowCollective() { }

        public StackOverflowCollective(StackOverflowTag stackOverflowTags, StackOverflowExternalLink stackOverflowExternalLinks, string collectiveDescription, string linkUrl, string collectiveName, string collectiveSlug)
        {
            StackOverflowTags = stackOverflowTags;
            StackOverflowExternalLinks = stackOverflowExternalLinks;
            CollectiveDescription = collectiveDescription;
            LinkUrl = linkUrl;
            CollectiveName = collectiveName;
            CollectiveSlug = collectiveSlug;
        }
    }
}