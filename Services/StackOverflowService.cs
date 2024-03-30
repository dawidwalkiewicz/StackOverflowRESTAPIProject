using Hammock.Web;
using Hammock;
using System.Xml.Serialization;
using StackOverflowRESTAPIProject.DTO;
using Newtonsoft.Json;

namespace StackOverflowRESTAPIProject.Services
{
    public class StackOverflowService
    {
        public const string URL_BASE = "https://api.stackexchange.com/2.3/";

        double totalItems;
        double totalTags;

        private static RestResponse GetResponse(string path)
        {
            var client = new RestClient()
            {
                Authority = URL_BASE,
                Method = WebMethod.Get
            };

            var request = new RestRequest { Path = path };

            return client.Request(request);
        }

        private static T Deserialize<T>(string xmlContent)
        {
            using var str = new StringReader(xmlContent);
            var deserializer = new XmlSerializer(typeof(T));
            return (T)deserializer.Deserialize(str);
        }

        public class ReadAndParseJsonFileWithNewtonsoftJson
        {
            private readonly string _sampleJsonFilePath;
            public ReadAndParseJsonFileWithNewtonsoftJson(string sampleJsonFilePath)
            {
                _sampleJsonFilePath = sampleJsonFilePath;
            }

            public List<StackOverflowTag> UseUserDefinedObjectWithNewtonsoftJson()
            {
                using StreamReader reader = new(_sampleJsonFilePath);
                var json = reader.ReadToEnd();
                List<StackOverflowTag>? tags = JsonConvert.DeserializeObject<List<StackOverflowTag>>(json);
                return tags;
            }
        }

        public StackOverflowTag GetTags()
        {
            var response = GetResponse("tags?min=1000&site=stackoverflow");
            return Deserialize<StackOverflowTag>(response.Content);
        }

        public void CountTags()
        {
            GetTags();
            double percentage = totalTags / totalItems * 100;
        }
    }
}