using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Products.Queries.Strategies;
using Application.UnitTests.Common.Helpers;
using AutoMapper;
using Moq;
using System.Collections.Generic;

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

            // Configure and setup IProductQueryFactory
            var mockProducstApi = new Mock<IProductsApi>();
            mockProducstApi.Setup(api => api.GetProductListAsync()).Returns(TestHelper.GetRandomProductsAsync());
            mockProducstApi.Setup(api => api.GetShopperHistoryAsync()).Returns(TestHelper.GetRandomShopperHistoryAsync());

            var mockAscendingProductsQuery = new Mock<AscendingProductsQuery>(mockProducstApi.Object);
            var mockDescendingProductsQuery = new Mock<DescendingProductsQuery>(mockProducstApi.Object);
            var mockHighProductsQuery = new Mock<HighProductsQuery>(mockProducstApi.Object);
            var mockLowProductsQuery = new Mock<LowProductsQuery>(mockProducstApi.Object);
            var mockRecommendedProductsQuery = new Mock<RecommendedProductsQuery>(mockProducstApi.Object);

            ProductQueries = new List<IProductQuery> 
            { 
                mockAscendingProductsQuery.Object,
                mockDescendingProductsQuery.Object,
                mockHighProductsQuery.Object,
                mockLowProductsQuery.Object,
                mockRecommendedProductsQuery.Object
            };
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }

        public IUserManager UserManager { get; }

        public IEnumerable<IProductQuery> ProductQueries { get; }
    }
}
