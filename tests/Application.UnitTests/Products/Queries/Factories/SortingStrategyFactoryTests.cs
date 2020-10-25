using Application.Common.Enums;
using Application.Common.Interfaces;
using Application.Products.Queries.Strategies;
using Application.UnitTests.Common.Fixtures;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.Products.Queries.Factories
{
    public class SortingStrategyFactoryTests : IClassFixture<TestFixture>
    {
        private readonly ISortingStrategyFactory _factory;

        public SortingStrategyFactoryTests(TestFixture fixture)
        {
            _factory = fixture.SortingStrategyFactory;
        }

        [Fact]
        public void GivenAscendingSortOption_AscendingSortingStrategy()
        {
            // Arrange
            var option = SortOption.Ascending;

            // Act
            var strategy = _factory.GetStrategy(option);

            // Assert
            strategy.Should().BeOfType<AscendingSortingStrategy>();
        }

        [Fact]
        public void GivenDescendingSortOption_DescendingSortingStrategy()
        {
            // Arrange
            var option = SortOption.Descending;

            // Act
            var strategy = _factory.GetStrategy(option);

            // Assert
            strategy.Should().BeOfType<DescendingSortingStrategy>();
        }

        [Fact]
        public void GivenHighSortOption_HighSortingStrategy()
        {
            // Arrange
            var option = SortOption.High;

            // Act
            var strategy = _factory.GetStrategy(option);

            // Assert
            strategy.Should().BeOfType<HighSortingStrategy>();
        }

        [Fact]
        public void GivenLowSortOption_LowSortingStrategy()
        {
            // Arrange
            var option = SortOption.Low;

            // Act
            var strategy = _factory.GetStrategy(option);

            // Assert
            strategy.Should().BeOfType<LowSortingStrategy>();
        }

        [Fact]
        public void GivenRecommendedSortOption_RecommendedSortingStrategy()
        {
            // Arrange
            var option = SortOption.Recommended;

            // Act
            var strategy = _factory.GetStrategy(option);

            // Assert
            strategy.Should().BeOfType<RecommendedSortingStrategy>();
        }
    }
}
