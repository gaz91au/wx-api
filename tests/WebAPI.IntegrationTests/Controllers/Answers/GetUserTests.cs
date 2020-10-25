using Application.Users.Queries;
using FluentAssertions;
using Infrastructure.Options;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using static WebAPI.IntegrationTests.Common.Utilities;

namespace WebAPI.IntegrationTests.Controllers.Answers
{
    public class GetUserTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetUserTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidRequest_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();
            var options = _factory.Services.GetService(typeof(UserOptions)) as UserOptions;
            var expectedName = options.Name;
            var expectedToken = options.Token;

            // Act
            var response = await client.GetAsync("/api/answers/user");
            var content = await GetResponseContent<UserDto>(response);

            // Assert
            content.Should().NotBeNull();
            content.Name.Should().BeEquivalentTo(expectedName);
            content.Token.Should().BeEquivalentTo(expectedToken);
        }
    }
}
