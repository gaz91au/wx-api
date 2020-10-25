using Application.Common.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static WebAPI.IntegrationTests.Common.Utilities;

namespace WebAPI.IntegrationTests.Controllers.Answers
{
    public class GetSortedProductListTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetSortedProductListTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenAscendingSortOption_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/answers/sort?sortoption=ascending");
            var content = await GetResponseContent<List<ProductDto>>(response);

            // Assert
            content.Should().NotBeNullOrEmpty();
            content.Should().BeInAscendingOrder(x => x.Name);
        }
        [Fact]
        public async Task GivenDescendingSortOption_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/answers/sort?sortoption=descending");
            var content = await GetResponseContent<List<ProductDto>>(response);

            // Assert
            content.Should().NotBeNullOrEmpty();
            content.Should().BeInDescendingOrder(x => x.Name);
        }

        [Fact]
        public async Task GivenHighSortOption_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/answers/sort?sortoption=high");
            var content = await GetResponseContent<List<ProductDto>>(response);

            // Assert
            content.Should().NotBeNullOrEmpty();
            content.Should().BeInDescendingOrder(x => x.Price);
        }

        [Fact]
        public async Task GivenLowSortOption_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/answers/sort?sortoption=low");
            var content = await GetResponseContent<List<ProductDto>>(response);

            // Assert
            content.Should().NotBeNullOrEmpty();
            content.Should().BeInAscendingOrder(x => x.Price);
        }

        [Fact]
        public async Task GivenRecommendedSortOption_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/answers/sort?sortoption=recommended");
            var content = await GetResponseContent<List<ProductDto>>(response);

            // Assert
            content.Should().NotBeNullOrEmpty();
            content.Should().BeInDescendingOrder(x => x.Quantity);
        }
    }
}
