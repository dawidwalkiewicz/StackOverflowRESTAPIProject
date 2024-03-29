using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackOverflowRESTAPIProject.Models;
using StackOverflowRESTAPIProject.Services;

namespace StackOverflowRESTAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackOverflowDataController : ControllerBase
    {
        static readonly string stackOverflowAPIUrl = "https://api.stackexchange.com/2.3/tags?";
        private static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri(stackOverflowAPIUrl)
        };
        string token = "";
        static string token_secret = "";
        private IConfiguration config;
        private readonly IConfiguration _config = config;

        public ActionResult? AuthenticateToStackOverflow()
        {
            var credentials = new OAuthCredentials {
                CallbackUrl = "http://localhost:3492/stackoverflowdata/callback",
                ConsumerKey = _config["client_id"],
                ConsumerSecret = _config["client_secret"],
                Verifier = "123456",
                Type = OAuthType.RequestToken
            };

            var client = new RestClient { Authority = " https://stackoverflow.com/oauth", Credentials = credentials };
            var request = new RestRequest { Path = "requestToken?client_id&scope=read_inbox,no_expiry,write_access,private_info&redirect_uri" };
            RestResponse response = client.Request(request);

            token = response.Content.Split('&')[0].Split('=')[1];
            token_secret = response.Content.Split('&')[1].Split('=')[1];
            Response.Redirect("https://www.stackoverflow.com/oauth/access_token=" + token);
            return null;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Callback()
        {
            token = Request["oauth_token"];
            verifier = Request["oauth_verifier"];
            var credentials = new OAuthCredentials
            {
                ConsumerKey = _config["client_id"],
                ConsumerSecret = _config["client_secret"],
                Token = token,
                TokenSecret = token_secret,
                Verifier = verifier,
                Type = OAuthType.AccessToken,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                Version = "1.0"
            };

            var client = new RestClient { Authority = "https://www.linkedin.com/uas/oauth2/accessToken", Credentials = credentials, Method = WebMethod.Post };
            var request = new RestRequest { Path = "/accessToken" };
            RestResponse response = client.Request(request);
            string content = response.Content;

            string accessToken = response.Content.Split('&')[0].Split('=')[1];
            string accessTokenSecret = response.Content.Split('&')[1].Split('=')[1];

            var tagSearchResult = new StackOverflowService(accessToken, accessTokenSecret).GetTagByName("Dawid");
            String peopleList = peopleSearchResult.People.Persons.ToString();
            return Content(peopleList);
        }

        [NonAction]
        public static async Task GetHttpClientAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync(_httpClient.BaseAddress + "min=1000&site=stackoverflow");
            if (response == null)
            {
                return;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                _ = JsonConvert.DeserializeObject<List<StackOverflowTag>>(content);
            }
        }
    }
}