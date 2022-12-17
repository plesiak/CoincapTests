using RestSharp;
using CoincapTask.Models;

namespace CoincapTask.Tests
{
    public class NegativeTests : TestBase
    {
        // I'd report scenarios 2nd and 3rd as bugs, for now I left those in here
        [Theory]
        [InlineData("test")]
        [InlineData("---")]
        [InlineData("ąąąććććółł")]
        public void GetAssetsByNonExistingId(string id)
        {
            var request = new RestRequest($"v2/assets/{id}");
            var (body, statusCode) = GetResponse<ErrorResponse>(request);

            Assert.Equal("NotFound", statusCode);
            Assert.Equal(body.Error, $"{id} not found");
        }

        // Won't work now - I'd report this behaviour as a bug, now it's returning 200 OK and data
        // even if you pass url params as below
        [Theory]
        [InlineData("sreach", "???")]
        [InlineData("api", "does")]
        [InlineData("not", "care")]
        public void FilterAssetsWithWrongParameters(string filterParam, string filterValue)
        {
            var request = new RestRequest($"v2/assets?{filterParam}={filterValue}");
            var (body, statusCode) = GetResponse<ErrorResponse>(request);

            Assert.Equal("BadRequest", statusCode);
            Assert.Equal(body.Error, $"{filterParam} not found");
        }

        
        [Theory]
        [InlineData(-1, "BadRequest", "limit/offset cannot be negative")]
        [InlineData(2001, "BadRequest", "limit exceeds 2000")]
        public void GetLimitedAssets(int limitValue, string expectedStatusCode, string expectedMsg)
        {
            var request = new RestRequest($"v2/assets?limit={limitValue}");
            var (body, statusCode) = GetResponse<ErrorResponse>(request);

            Assert.Equal(expectedStatusCode, statusCode);
            Assert.Equal(expectedMsg, body.Error);
        }
    }
}