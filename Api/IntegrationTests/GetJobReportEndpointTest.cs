using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class GetJobReportEndpointTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetJobReportEndpointTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CanCreateJobs()
        {
            var client = _factory.CreateClient();
            var request = new CreateJobsRequest
            {
                Data = new []
                {
                    "random data 1",
                    "random data 2"
                },
                Type = "Bulk"
            };
            
            // TODO: Encapsulate JSON body request parse
            var jsonRequest = JsonConvert.SerializeObject(request);
            var response = await client.PostAsync("/api/v1/job", new StringContent(jsonRequest, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            // TODO: Encapsulate JSON body response parse
            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var bodyResponse = JsonConvert.DeserializeObject<CreateJobResponse>(jsonResponse);
            
            Assert.Equal(2, bodyResponse.DataPointsCreated);
        }
    }
}