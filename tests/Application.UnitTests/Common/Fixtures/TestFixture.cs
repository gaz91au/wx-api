using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Products.Queries.Factories;
using Application.Products.Queries.Strategies;
using Application.UnitTests.Common.Helpers;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UnitTests.Common.Fixtures
{
    public class TestFixture
    {
        public TestFixture()
        {
            // Configure and setup Automapper
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();

            // Configure and setup IUserManager
            var mockUserManager = new Mock<IUserManager>();
            mockUserManager.Setup(manager => manager.GetName()).Returns("Gary Huynh"); // Ideally this should be retrieved from a configuration file.
            mockUserManager.Setup(manager => manager.GetToken()).Returns("9131dc22-281c-42bd-891b-d7f3416aa688"); // Ideally this should be retrieved from a configuration file.

            UserManager = mockUserManager.Object;

            // Configure and setup IProductsApi
            var mockProducstApi = new Mock<IProductsApi>();
            mockProducstApi.Setup(api => api.GetProductListAsync()).Returns(Task.FromResult(TestHelper.GetRandomProducts()));
            mockProducstApi.Setup(api => api.GetShopperHistoryAsync()).Returns(Task.FromResult(TestHelper.GetRandomShopperHistory()));

            ProductsApi = mockProducstApi.Object;

            // Configure and setup ISortingStrategyFactory
            var mockAscendingSortingStrategy = new Mock<AscendingSortingStrategy>();
            var mockDescendingSortingStrategy = new Mock<DescendingSortingStrategy>();
            var mockHighSortingStrategy = new Mock<HighSortingStrategy>();
            var mockLowSortingStrategy = new Mock<LowSortingStrategy>();
            var mockRecommendedSortingStrategy = new Mock<RecommendedSortingStrategy>(mockProducstApi.Object);

            var hihi = new SortingStrategyFactory(mockAscendingSortingStrategy.Object,
                mockDescendingSortingStrategy.Object,
                mockHighSortingStrategy.Object,
                mockLowSortingStrategy.Object,
                mockRecommendedSortingStrategy.Object);
    
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }

        public IUserManager UserManager { get; }

        public ISortingStrategyFactory SortingStrategyFactory { get; }

        public IProductsApi ProductsApi { get; }
    }
}
