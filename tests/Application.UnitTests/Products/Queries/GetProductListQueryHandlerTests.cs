using Application.Common.Enums;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Products.Queries;
using Application.UnitTests.Common.Fixtures;
using AutoMapper;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Products.Queries
{
    public class GetProductListQueryHandlerTests : IClassFixture<TestFixture>
    {
        private readonly IMapper _mapper;
        private readonly IProductsApi _productsApi;
        private readonly ISortingStrategyFactory _sortingStrategyFactory;
        
        public GetProductListQueryHandlerTests(TestFixture fixture)
        {
            _mapper = fixture.Mapper;
            _productsApi = fixture.ProductsApi;
            _sortingStrategyFactory = fixture.SortingStrategyFactory;
        }

        [Fact]
        public async Task GivenAscendingSortOption_ShouldReturn_ProductsInAscendingOrder()
        {
            // Arrange
            var query = new GetProductListQuery() { SortOption = "ascending" };
            var handler = new GetProductListQueryHandler(_mapper, _productsApi, _sortingStrategyFactory);

            // Act
            var response = await handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().BeOfType<List<ProductDto>>();
            response.Should().BeInAscendingOrder(x => x.Name);
        }

        [Fact]
        public async Task GivenDescendingSortOption_ShouldReturn_ProductsInDescendingOrder()
        {
            // Arrange
            var query = new GetProductListQuery() { SortOption = "descending" };
            var handler = new GetProductListQueryHandler(_mapper, _productsApi, _sortingStrategyFactory);

            // Act
            var response = await handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().BeOfType<List<ProductDto>>();
            response.Should().BeInDescendingOrder(x => x.Name);
        }

        [Fact]
        public async Task GivenHighSortOption_ShouldReturn_ProductsInHighOrder()
        {
            // Arrange
            var query = new GetProductListQuery() { SortOption = "high" };
            var handler = new GetProductListQueryHandler(_mapper, _productsApi, _sortingStrategyFactory);

            // Act
            var response = await handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().BeOfType<List<ProductDto>>();
            response.Should().BeInDescendingOrder(x => x.Price);
        }

        [Fact]
        public async Task GivenLowSortOption_ShouldReturn_ProductsInLowOrder()
        {
            // Arrange
            var query = new GetProductListQuery() { SortOption = "low" };
            var handler = new GetProductListQueryHandler(_mapper, _productsApi, _sortingStrategyFactory);

            // Act
            var response = await handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().BeOfType<List<ProductDto>>();
            response.Should().BeInAscendingOrder(x => x.Price);
        }

        [Fact]
        public async Task GivenRecommendedSortOption_ShouldReturn_ProductsInRecommendedOrder()
        {
            // Arrange
            var query = new GetProductListQuery() { SortOption = "recommended" };
            var handler = new GetProductListQueryHandler(_mapper, _productsApi, _sortingStrategyFactory);

            // Act
            var response = await handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNullOrEmpty();
            response.Should().BeOfType<List<ProductDto>>();
            response.Should().BeInDescendingOrder(x => x.Quantity);
        }
    }
}
