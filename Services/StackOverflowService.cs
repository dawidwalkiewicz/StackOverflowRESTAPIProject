using Hammock.Authentication.OAuth;
using Hammock.Web;
using Hammock;
using System.Text;
using System.Xml.Serialization;
using System;
using StackOverflowRESTAPIProject.DTO;

namespace StackOverflowRESTAPIProject.Services
{
    public class StackOverflowService
    {
        private const string URL_BASE = "https://api.stackexchange.com/2.3/";
        public static string ConsumerKey { get { return ConfigurationManager.AppSettings["ConsumerKey"]; } }
        public static string ConsumerKeySecret { get { return ConfigurationManager.AppSettings["ConsumerSecret"]; } }
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
                    ConsumerKey = ConsumerKey,
                    ConsumerSecret = ConsumerKeySecret,
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

        private T Deserialize<T>(string xmlContent)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xmlContent));
            using (var str = new StringReader(xmlContent))
            {
                var deserializer = new XmlSerializer(typeof(T));
                return (T)deserializer.Deserialize(str);
            }
        }

        #endregion

        #region StackOverflowTag Information

        public StackOverflowTag GetCurrentUser()
        {
            var response = GetResponse("people/~");
            return Deserialize<StackOverflowTag>(response.Content);
        }

        #endregion
    }
}