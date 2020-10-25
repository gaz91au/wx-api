using Application.Common.Interfaces;
using Application.Products.Queries.Strategies;
using Application.UnitTests.Common.Fixtures;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Products.Queries.Strategies
{
    public class LowSortingStrategyTests : IClassFixture<TestFixture>
    {
        private readonly IProductsApi _productsApi;

        public LowSortingStrategyTests(TestFixture fixture)
        {
            _productsApi = fixture.ProductsApi;
        }

        [Fact]
        public async Task GivenProducts_ShouldReturnSortedList()
        {
            // Arrange
            var strategy = new LowSortingStrategy();
            var products = await _productsApi.GetProductListAsync();

            // Act
            var response = strategy.Sort(products);

            // Assert
            response.Should().BeInAscendingOrder(x => x.Price);
        }
    }
}
