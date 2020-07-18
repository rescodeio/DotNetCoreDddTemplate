using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests
{
    public class UserTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;  
        }
        
        [Fact]
        public async Task WhereName()
        {
            var client = _factory.CreateClient();
            await client.GetAsync("/api/v1/user/generate/acdc");
            var response = await client.GetAsync("/api/v1/user/name/acdc").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains(",\"name\":\"acdc\"}]", content);
        }
        
        [Fact]
        public async Task Count()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/v1/user/count").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var count = await response.Content.ReadAsStringAsync();
            Assert.Equal("0", count);
        }
    }
}