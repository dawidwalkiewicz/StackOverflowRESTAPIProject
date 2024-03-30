namespace StackOverflowRESTAPIProject.DTO
{
    public class StackOverflowTag
    {
        public string? TagName { get; set; }
        public int? TagCount { get; set; }
        public bool? IsModeratorOnly { get; set; }
        public bool? HasSynonyms { get; set; }
        public bool? IsRequired { get; set; }
    }
}