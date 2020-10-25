using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.IntegrationTests.Controllers.Answers
{
    public class CalculateTrolleyTotalTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CalculateTrolleyTotalTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidRequest_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = client.GetAsync("/api/answers/trolleyTotal");

            // Assert
        }
    }
}
