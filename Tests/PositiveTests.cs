using RestSharp;
using CoincapTask.Models;

namespace CoincapTask.Tests
{
    public class PositiveTests : TestBase
    {
        
        // TODO: cover more scenarios for below endpoints AND returning by ID/history part
        [Fact]
        public void GetAllAssets()
        {
            var request = new RestRequest("v2/assets");
            var (body, statusCode) = GetResponse<Cryptocurrencies>(request);

            Assert.Equal("OK", statusCode);
            Assert.NotEmpty(body.Data);
        }

        // just a simple example of checking if filtering by different filters returns the same
        // could add additional values to be checked
        // assertions to be improved
        [Theory]
        [InlineData("bitcoin-bep2", "BTCB")]
        public void GetAssetsByGivenParameter(string id, string symbol)
        {
            var requestById = new RestRequest($"v2/assets?search={id}");
            var requestBySymbol = new RestRequest($"v2/assets?search={symbol}");

            var responseById = GetResponse<Cryptocurrencies>(requestById);
            var responseBySymbol = GetResponse<Cryptocurrencies>(requestBySymbol);
            
            Assert.Equal("OK", responseById.statusCode);
            Assert.Equal("OK", responseBySymbol.statusCode);
            Assert.Single(responseById.body.Data);
            Assert.Single(responseBySymbol.body.Data);

            Assert.Equal(responseById.body.Data.First().Symbol, responseBySymbol.body.Data.First().Symbol);
        }

        [Theory]
        [InlineData(0, "OK")] // mig
        [InlineData(5, "OK")]
        [InlineData(2000, "OK")]
        public void GetLimitedAssets(int limitValue, string expectedStatusCode)
        {
            var request = new RestRequest($"v2/assets?limit={limitValue}");
            var (body, statusCode) = GetResponse<Cryptocurrencies>(request);

            Assert.Equal(expectedStatusCode, statusCode);
            Assert.Equal(limitValue, body.Data.Count);
        }

        // some cryptos will return different markets when containing part of string
        // I could come up with other scenarios here, solana just a simple example when TrueForAll will be true
        [Theory]
        [InlineData("solana", "SOL")]
        public void GetRatesById(string id, string symbol)
        {
            var request = new RestRequest($"v2/assets/{id}/markets");
            var response = GetResponse<Markets>(request);
            
            Assert.Equal("OK", response.statusCode);
            Assert.True(response.body.Data.TrueForAll(_ => _.BaseId.Equals(id) && _.BaseSymbol.Equals(symbol)));
        }
    }
}