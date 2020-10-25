using Application.Common.Interfaces;
using Application.Products.Queries.Strategies;
using Application.UnitTests.Common.Fixtures;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Products.Queries.Strategies
{
    public class DescendingSortingStrategyTests : IClassFixture<TestFixture>
    {
        private readonly IProductsApi _productsApi;

        public DescendingSortingStrategyTests(TestFixture fixture)
        {
            _productsApi = fixture.ProductsApi;
        }

        [Fact]
        public async Task GivenProducts_ShouldReturn_SortedList()
        {
            // Arrange
            var strategy = new DescendingSortingStrategy();
            var products = await _productsApi.GetProductListAsync();

            // Act
            var response = strategy.Sort(products);

            // Assert
            response.Should().BeInDescendingOrder(x => x.Name);
        }
    }
}
