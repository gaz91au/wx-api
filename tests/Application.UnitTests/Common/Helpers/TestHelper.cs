using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UnitTests.Common.Helpers
{
    public static class TestHelper
    {
        public static async Task<IList<Product>> GetRandomProductsAsync()
        {
            var rng = new Random();

            var products = Enumerable.Range(10, 100).Select(index => new Product
            {
                Name = Guid.NewGuid().ToString(),
                Price = Convert.ToDecimal(rng.Next(0, 100)),
                Quantity = Convert.ToDecimal(rng.Next(0, 100))
            }).ToList();

            return products;
        }

        public static async Task<IList<ShopperHistory>> GetRandomShopperHistoryAsync()
        {
            var rng = new Random();

            return Enumerable.Range(10, 100).Select(index => new ShopperHistory
            {
                CustomerId = rng.Next(0, 100),
                Products = GetRandomProductsAsync().GetAwaiter().GetResult()
            }).ToList();
        }
    }
}
