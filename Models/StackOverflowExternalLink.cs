namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowExternalLink
    {
        public string ExternalLinkType { get; set; }
        public string ExternalLinkUrl { get; set; }
        
        protected StackOverflowExternalLink() { }

        public StackOverflowExternalLink(string externalLinkType, string externalLinkUrl)
        {
            ExternalLinkType = externalLinkType;
            ExternalLinkUrl = externalLinkUrl;
        }
    }
}