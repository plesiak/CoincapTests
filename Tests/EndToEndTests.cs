using RestSharp;
using CoincapTask.Models;

namespace CoincapTask.Tests
{
    public class EndToEndTests : TestBase
    {
        [Theory]
        [InlineData("ethereum")]
        public void EndToEndForEthereum(string id)
        {
            var request = new RestRequest($"v2/assets/{id}");
            var (body, statusCode) = GetResponse<Cryptocurrencies>(request);

            if (statusCode.Equals("OK"))
            {
                var historyRequest = new RestRequest($"v2/assets/{id}/history?interval=h12");
                var (historyBody, historyStatusCode) = GetResponse<List<History>>(request);
                Assert.Equal("OK", historyStatusCode);
                Assert.NotEmpty(historyBody);
            }
        }
    }
}