using static StackOverflowRESTAPIProject.Services.StackOverflowService;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IStackOverflowService
    {
        Task GetTagsFromApi(uint count);
        Task<List<TagItem>?> GetTagsAsync(uint page, uint pageSize);
        Task CountTags(uint tagsCount);
    }
}