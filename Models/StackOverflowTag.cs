namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowTag
    {
        public string TagName { get; set; }
        public int TagCount { get; set; }
        public bool IsModeratorOnly { get; set; }
        public bool HasSynonyms { get; set; }
        public bool IsRequired { get; set; }

        protected StackOverflowTag() { }

        public StackOverflowTag(string tagName, int tagCount, bool isModeratorOnly, bool hasSynonyms, bool isRequired)
        {
            TagName = tagName.ToLowerInvariant();
            TagCount = tagCount;
            IsModeratorOnly = isModeratorOnly;
            HasSynonyms = hasSynonyms;
            IsRequired = isRequired;
        }
    }
}