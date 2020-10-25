﻿using Application.Common.Interfaces;
using Application.Products.Queries.Strategies;
using Application.UnitTests.Common.Fixtures;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Products.Queries.Strategies
{
    public class AscendingProductsQueryTests : IClassFixture<TestFixture>
    {
        private readonly IProductsApi _productsApi;

        public AscendingProductsQueryTests(TestFixture fixture)
        {
            _productsApi = fixture.ProductsApi;
        }

        [Fact]
        public async Task GivenValidQuery_ShouldReturnCorrectProductList()
        {
            // Arrange
            var query = new AscendingProductsQuery(_productsApi);

            // Act
            var response = await query.GetProducts();

            // Assert
            response.Should().BeInAscendingOrder(x => x.Name);
        }
    }
}
