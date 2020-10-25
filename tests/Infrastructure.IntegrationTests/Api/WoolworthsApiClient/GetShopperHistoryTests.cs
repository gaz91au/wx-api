using Domain.Entities;
using FluentAssertions;
using Infrastructure.IntegrationTests.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.IntegrationTests.Api.WoolworthsApiClient
{
    public class GetShopperHistoryTests
    {
        [Fact]
        public async Task GetShopperHistoryAsync_ShouldReturn_CorrectResponse()
        {
            // Arrange
            var client = new WoolworthsApiClientFactory().CreateClient();

            // Act
            var response = await client.GetShopperHistoryAsync();

            // Assert
            response.Should().BeOfType<List<ShopperHistory>>();
            response.Should().NotBeNullOrEmpty();
        }
    }
}
