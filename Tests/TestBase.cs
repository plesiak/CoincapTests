using CoincapTask.Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace CoincapTask.Tests
{
    public class TestBase
    {
        protected string BaseUrl = ConfigHelper.ConfigEntries.BaseUrl;
        protected string ApiKey = ConfigHelper.ConfigEntries.ApiKey;
        protected readonly RestClient Client;
        
        // TODO: DI for injecting RestClient with options
        public TestBase()
        {
            //Client = new RestClient(BaseUrl);
            Client = RestClientWithHeaders();
        }

        private RestClient RestClientWithHeaders()
        {
            var restClient = new RestClient(BaseUrl);
            restClient.AddDefaultHeader("Authorization", "Bearer " + ApiKey);

            return restClient;
        }

        protected (T body, string statusCode) GetResponse<T>(RestRequest restRequest)
        {
            var restResponse = Client.Execute(restRequest);
            return (JsonConvert.DeserializeObject<T>(restResponse.Content), restResponse.StatusCode.ToString());
        }
    }
}