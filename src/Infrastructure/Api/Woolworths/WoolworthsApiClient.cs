using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Api
{
    public class WoolworthsApiClient : IProductsApi
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IUserManager _userManager;
        private readonly ApiOptions _apiOptions;

        public WoolworthsApiClient(IHttpClientFactory clientFactory, IUserManager userManager, ApiOptions apiOptions)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _apiOptions = apiOptions ?? throw new ArgumentNullException(nameof(apiOptions));
        }

        public async Task<IList<Product>> GetProductListAsync()
        {
            var resourceUri = "api/resource/products";

            var uri = BuildRequestUri(resourceUri);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public async Task<IList<ShopperHistory>> GetShopperHistoryAsync()
        {
            var resourceUri = "api/resource/shopperhistory";

            var uri = BuildRequestUri(resourceUri);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ShopperHistory>>(json);
        }

        private string BuildRequestUri(string resourceUri) => _apiOptions.BaseUri + resourceUri + $"?token={_userManager.GetToken()}";
    }
}
