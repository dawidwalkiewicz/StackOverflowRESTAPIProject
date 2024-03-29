using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackOverflowRESTAPIProject.Services;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System;
using StackOverflowRESTAPIProject.Models;

namespace StackOverflowRESTAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackOverflowDataController : ControllerBase
    {
        [HttpGet]
        private StackOverflowService GetTags()
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
            return GetTags();
        }
    }
}