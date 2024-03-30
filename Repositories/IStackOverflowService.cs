using StackOverflowRESTAPIProject.DTO;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowService
    {
        Task GetTagsFromApi(uint count);
        Task<List<TagItem>> GetTags(uint page, uint pageSize);
        Task CountTags();
        public class TagItem : StackOverflowTag
        {
            public bool HasSynonyms { get; set; }
            public bool IsModeratorOnly { get; set; }
            public bool IsRequired { get; set; }
            public int Count { get; set; }
            public string Name { get; set; }
        }
    }
}