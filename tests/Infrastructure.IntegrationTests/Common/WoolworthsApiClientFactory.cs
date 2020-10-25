using Application.Common.Interfaces;
using Infrastructure.Api;
using Infrastructure.Options;
using Moq;
using System;
using System.Net.Http;

namespace Infrastructure.IntegrationTests.Common
{
    public class WoolworthsApiClientFactory
    {
        public WoolworthsApiClient CreateClient()
        {
            // Initialize and setup IHttpClientFactory mock
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(new HttpClient());

            // Initialize and setup IUserManager mock
            var mockUserManager = new Mock<IUserManager>();
            mockUserManager.Setup(manager => manager.GetToken()).Returns("9131dc22-281c-42bd-891b-d7f3416aa688");

            // Initialize and setup ApiOptions mock
            var mockApiOptions = new Mock<ApiOptions>("http://dev-wooliesx-recruitment.azurewebsites.net/");

            // Create a WoolworthsApiClient using mocked constructor parameters
            return new WoolworthsApiClient(
                mockHttpClientFactory.Object,
                mockUserManager.Object,
                mockApiOptions.Object);
        }
    }
}
