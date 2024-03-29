namespace StackOverflowRESTAPIProject.DTO
{
    public class StackOverflowCollective
    {
        public StackOverflowTag? StackOverflowTags { get; set; }
        public StackOverflowExternalLink? StackOverflowExternalLinks { get; set; }
        public string? CollectiveDescription { get; set; }
        public string? LinkUrl { get; set; }
        public string? CollectiveName { get; set; }
        public string? CollectiveSlug { get; set; }
    }
}