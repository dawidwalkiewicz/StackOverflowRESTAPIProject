using Microsoft.AspNetCore.Mvc;
using Hammock;
using StackOverflowRESTAPIProject.Models;
using Newtonsoft.Json;

namespace StackOverflowRESTAPIProject.Controllers
{
    public class StackOverflowDataController : ControllerBase
    {
        static readonly string stackOverflowAPIUrl = "https://api.stackexchange.com/2.3/tags?";
        private static HttpClient _httpClient = new();

        [HttpGet]
        public async Task<IActionResult> GetTag(string url)
        {
            url = $"{stackOverflowAPIUrl}min=1000&site=stackoverflow";
            var tag = await _httpClient.GetAsync(url);
            if (tag.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await tag.Content.ReadAsStringAsync();
                _ = JsonConvert.DeserializeObject<List<StackOverflowTag>>(content);
            }
            return Json(tag);
        }
    }
}