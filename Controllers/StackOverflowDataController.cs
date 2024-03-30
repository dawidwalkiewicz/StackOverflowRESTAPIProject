using Microsoft.AspNetCore.Mvc;
using StackOverflowRESTAPIProject.Models;
using StackOverflowRESTAPIProject.Services;
using System.Net.Http.Headers;
using System.Text.Json;

namespace StackOverflowRESTAPIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StackOverflowDataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<StackOverflowTag> Get()
        {
            return GetTags();
        }

        private List<StackOverflowTag> GetTags()
        {
            return new List<StackOverflowTag>();
        }

        [HttpPost]
        [Produces("application/json")]
        public StackOverflowTag Post([FromBody] StackOverflowTag stackOverflowTag)
        {
            string page = StackOverflowService.URL_BASE + "tags?min=1000&site=stackoverflow";

            using HttpClient client = new();
            using HttpResponseMessage response = client.GetAsync(page).Result;
            using HttpContent content = response.Content;
            string result = content.ReadAsStringAsync().Result;
            using FileStream createStream = System.IO.File.Create(@"D:\Dokumenty\DoPracy\StackOverflowRESTAPIProject\stackoverflowdata.json");
            JsonSerializer.SerializeAsync(createStream, result);
            return new StackOverflowTag("javascript", 2528363, false, true, false);
        }
    }
}