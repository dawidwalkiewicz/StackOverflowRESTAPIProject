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
            using var client = new HttpClient();
            string urlParameters = "tags?min=1000&site=stackoverflow";
            client.BaseAddress = new Uri(StackOverflowService.URL_BASE);

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
            }
        }

        [NonAction]
        public static void Main()
        {
            Task t = new(DownloadPageAsync);
            t.Start();
        }

        [NonAction]
        public static async void DownloadPageAsync()
        {
            string page = StackOverflowService.URL_BASE + "tags?min=1000&site=stackoverflow";

            using HttpClient client = new();
            using HttpResponseMessage response = await client.GetAsync(page);
            using HttpContent content = response.Content;
            string result = await content.ReadAsStringAsync();
            await using FileStream createStream = System.IO.File.Create(@"D:\Dokumenty\DoPracy\StackOverflowRESTAPIProject\stackoverflowdata.json");
            await JsonSerializer.SerializeAsync(createStream, result);
        }
    }
}