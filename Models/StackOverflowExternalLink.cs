namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowExternalLink
    {
        public string ExternalLinkType { get; set; }
        public string ExternalLinkUrl { get; set; }

        public StackOverflowExternalLink(string externalLinkType, string externalLinkUrl)
        {
            ExternalLinkType = externalLinkType;
            ExternalLinkUrl = externalLinkUrl;
        }
    }
}