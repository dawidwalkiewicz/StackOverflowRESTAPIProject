using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowRESTAPIProject.DTO;
using StackOverflowRESTAPIProject.Repositories;
using System.Net;

namespace StackOverflowRESTAPIProject.Services
{
    public class StackOverflowService : IStackOverflowService
    {
        public const string URL_BASE = "https://api.stackexchange.com/2.3/";

        private List<KeyValuePair<string, TagItem>> _tagItemsCache = [];
        private readonly ILogger<StackOverflowService> _logger;

        public StackOverflowService(ILogger<StackOverflowService> logger = null)
        {
            GetTagsFromApi(1000).Wait();
            _logger = logger;
        }

        public async Task GetTagsFromApi(uint count)
        {
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using HttpClient client = new(clientHandler)
            {
                BaseAddress = new Uri(URL_BASE)
            };

            var pageCount = count / 100;
            var pageSize = 100;

            for (uint page = 1; page <= pageCount; page++)
            {
                var tags = await client.GetFromJsonAsync<Root>($"tags?page={page}&pagesize={pageSize}&site=stackoverflow");
                if (tags is not null)
                {
                    _tagItemsCache = tags.Items.Select(tag => new KeyValuePair<string, TagItem>(tag.Name, tag)).ToList();
                }
            }
        }

        public async Task<List<TagItem>?> GetTagsAsync(uint page = 1, uint pageSize = 100)
        {
            if (pageSize > 100)
            {
                throw new ArgumentException("Page size cannot be greater than 100");
            }

            if (page < 1)
            {
                throw new ArgumentException("Page number cannot be less than 1");
            }
            return await Task.FromResult(_tagItemsCache.Select(t => t.Value).ToList());
        }


        public async Task CountTags(uint tagsCount)
        {
            var tags = GetTagsFromApi(tagsCount);
            /*int quotaMax = tags.Contains("quota_max");
            int quotaRemaining = Request.Url.AbsoluteUri.Contains("quota_remaining");
            double percentage = quotaRemaining / quotaMax * 100;*/
        }

        public class Root
        {
            public List<TagItem> Items { get; set; }
            public bool HasMore { get; set; }
            public int QuotaMax { get; set; }
            public int QuotaRemaining { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

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