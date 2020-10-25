using Bogus;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UnitTests.Common.Helpers
{
    public static class TestHelper
    {
        public static IList<Product> GetRandomProducts()
        {
            var products = new List<Product>();

            var rng = new Random();

            for (int i = 0; i < rng.Next(5, 500); i++)
            {
                var faker = new Faker<Product>()
                .RuleFor(u => u.Name, f => f.Commerce.ProductName())
                .RuleFor(u => u.Quantity, f => f.Random.Decimal(1, 100))
                .RuleFor(u => u.Price, f => Convert.ToDecimal(f.Commerce.Price()));

                products.Add(faker.Generate());
            };

            return products;
        }

        public static IList<ShopperHistory> GetRandomShopperHistory()
        {
            var history = new List<ShopperHistory>();

            var rng = new Random();

            for (int i = 1; i < rng.Next(5, 500); i++)
            {
                history.Add(new ShopperHistory
                {
                    CustomerId = i,
                    Products = GetRandomProducts()
                });
            };

            return history;
        }
    }
}
