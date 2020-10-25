using Application.Common.Enums;

namespace Application.Common.Interfaces
{
    public interface ISortingStrategyFactory
    {
        ISortingStrategy GetStrategy(SortOption sortOption);
    }
}
