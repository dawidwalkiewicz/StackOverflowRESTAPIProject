using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;

namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowTag
    {
        public string TagName { get; set; }
        public int TagCount { get; set; }
        public bool IsModeratorOnly { get; set; }
        public bool HasSynonyms { get; set; }
        public bool IsRequired { get; set; }
        public StackOverflowCollective StackOverflowCollectives { get; set; }

        protected StackOverflowTag() { }

        /*public StackOverflowTag(string tagName, int tagCount, bool isModeratorOnly, bool hasSynonyms, bool isRequired, StackOverflowCollective stackOverflowCollectives)
        {
            TagName = tagName;
            TagCount = tagCount;
            IsModeratorOnly = isModeratorOnly;
            HasSynonyms = hasSynonyms;
            IsRequired = isRequired;
            StackOverflowCollectives = stackOverflowCollectives;
        }*/
        public StackOverflowTag(string json)
        {
            JObject jObject = JObject.Parse(json);
            TagName = (string)jObject["name"];
            TagCount = (int)jObject["count"];
            IsModeratorOnly = (bool)jObject["is_moderator_only"];
            HasSynonyms = (bool)jObject["has_synonyms"];
            IsRequired = (bool)jObject["is_required"];
            //StackOverflowCollectives = (StackOverflowCollective)jObject["collective"];
        }
    }
}