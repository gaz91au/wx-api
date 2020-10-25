using Domain.Entities;
using FluentAssertions;
using Infrastructure.IntegrationTests.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.IntegrationTests.Api.WoolworthsApiClient
{
    public class GetProductListTests
    {

        [Fact]
        public async Task GetProductListAsync_ShouldReturnCorrectResponse()
        {
            // Arrange
            var client = new WoolworthsApiClientFactory().CreateClient();

            // Act
            var response = await client.GetProductListAsync();

            // Assert
            response.Should().BeOfType<List<Product>>();
            response.Should().NotBeNullOrEmpty();
        }
    }
}
