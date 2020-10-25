using Application.Common.Enums;
using Application.Common.Interfaces;
using Application.Products.Queries.Strategies;
using System;

namespace Application.Products.Queries.Factories
{
    public class SortingStrategyFactory : ISortingStrategyFactory
    {
        private readonly AscendingSortingStrategy _ascendingSortingStrategy;
        private readonly DescendingSortingStrategy _descendingSortingStrategy;
        private readonly HighSortingStrategy _highSortingStrategy;
        private readonly LowSortingStrategy _lowSortingStrategy;
        private readonly RecommendedSortingStrategy _recommendedSortingStrategy;

        public SortingStrategyFactory(
            AscendingSortingStrategy ascendingSortingStrategy,
            DescendingSortingStrategy descendingSortingStrategy,
            HighSortingStrategy highSortingStrategy,
            LowSortingStrategy lowSortingStrategy,
            RecommendedSortingStrategy recommendedSortingStrategy)
        {
            _ascendingSortingStrategy = ascendingSortingStrategy ?? throw new ArgumentNullException(nameof(ascendingSortingStrategy));
            _descendingSortingStrategy = descendingSortingStrategy ?? throw new ArgumentNullException(nameof(descendingSortingStrategy));
            _highSortingStrategy = highSortingStrategy ?? throw new ArgumentNullException(nameof(highSortingStrategy));
            _lowSortingStrategy = lowSortingStrategy ?? throw new ArgumentNullException(nameof(lowSortingStrategy));
            _recommendedSortingStrategy = recommendedSortingStrategy ?? throw new ArgumentNullException(nameof(recommendedSortingStrategy));
        }

        public ISortingStrategy GetStrategy(SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                    return _lowSortingStrategy;
                case SortOption.High:
                    return _highSortingStrategy;
                case SortOption.Ascending:
                    return _ascendingSortingStrategy;
                case SortOption.Descending:
                    return _descendingSortingStrategy;
                case SortOption.Recommended:
                    return _recommendedSortingStrategy;
                default:
                    throw new NotSupportedException($"Sort Option: {sortOption} is not supported.");
            }
        }
    }
}
