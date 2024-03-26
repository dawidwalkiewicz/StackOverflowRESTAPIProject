using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;

namespace StackOverflowRESTAPIProject.Controllers
{
    public class StackOverflowDataController : ControllerBase
    {
        static string stackOverflowAPIUrl = "https://api.stackexchange.com/tags?min=1000&site=stackoverflow";
        readonly HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
        readonly HttpResponse response = client.GetAsync(stackOverflowAPIUrl);
        readonly HttpResponseStreamWriter streamResponse = response.Content.ReadAsStreamAsync();
    }
}