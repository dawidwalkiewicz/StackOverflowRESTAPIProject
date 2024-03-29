using Hammock.Authentication.OAuth;
using Hammock.Web;
using Hammock;
using System.Xml.Serialization;
using StackOverflowRESTAPIProject.DTO;

namespace StackOverflowRESTAPIProject.Services
{
    public class StackOverflowService
    {
        public const string URL_BASE = "https://api.stackexchange.com/2.3/";
        public static string? ClientId { get { return System.Configuration.ConfigurationManager.AppSettings["client_id"]; } }
        public static string? ClientSecret { get { return System.Configuration.ConfigurationManager.AppSettings["client_secret"]; } }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public StackOverflowService(string accessToken, string accessTokenSecret)
        {
            this.AccessToken = accessToken;
            this.AccessTokenSecret = accessTokenSecret;
        }

        private OAuthCredentials AccessCredentials
        {
            get
            {
                return new OAuthCredentials
                {
                    Type = OAuthType.AccessToken,
                    SignatureMethod = OAuthSignatureMethod.HmacSha1,
                    ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                    ConsumerKey = ClientId,
                    ConsumerSecret = ClientSecret,
                    Token = AccessToken,
                    TokenSecret = AccessTokenSecret
                };
            }
        }

        #region Helper

        private RestResponse GetResponse(string path)
        {
            var client = new RestClient()
            {
                Authority = URL_BASE,
                Credentials = AccessCredentials,
                Method = WebMethod.Get
            };

            var request = new RestRequest { Path = path };

            return client.Request(request);
        }

        private static T Deserialize<T>(string xmlContent)
        {
            //MemoryStream memoryStream = new(Encoding.ASCII.GetBytes(xmlContent));
            using var str = new StringReader(xmlContent);
            var deserializer = new XmlSerializer(typeof(T));
            return (T)deserializer.Deserialize(str);
        }

        #endregion

        public StackOverflowTag GetTags()
        {
            var response = GetResponse("tags?min=1000&site=stackoverflow");
            return Deserialize<StackOverflowTag>(response.Content);
        }

        public StackOverflowCollective GetCollectives()
        {
            var response = GetResponse("collectives?min=1000&site=stackoverflow");
            return Deserialize<StackOverflowCollective>(response.Content);
        }
    }
}