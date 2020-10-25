using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Queries.Strategies
{
    public class RecommendedSortingStrategy : ISortingStrategy
    {
        private readonly IProductsApi _productsApi;

        public RecommendedSortingStrategy(IProductsApi productsApi)
        {
            _productsApi = productsApi ?? throw new ArgumentNullException(nameof(productsApi));
        }

        public IList<Product> Sort(IList<Product> products)
        {
            var shopperHistories = _productsApi.GetShopperHistoryAsync().GetAwaiter().GetResult();

            if (shopperHistories == null)
            {
                throw new NotFoundException(nameof(ShopperHistory));
            }

            var purchasedProducts = new List<Product>();

            foreach (var history in shopperHistories)
            {
                if (history.Products != null)
                {
                    foreach (var product in history.Products)
                    {
                        purchasedProducts.Add(product);
                    }
                }
            }

            var groupedPurchasedProducts = purchasedProducts
                                            .GroupBy(x => x.Name)
                                            .Select(p => new Product
                                            {
                                                Name = p.First().Name,
                                                Price = p.First().Price,
                                                Quantity = p.Sum(s => s.Quantity)
                                            });

            var productWithQuantities = new List<Product>();

            foreach (var product in products)
            {
                var totalQuantity = 0m;

                var productHistory = groupedPurchasedProducts.FirstOrDefault(s => s.Name == product.Name);

                if (productHistory != null)
                {
                    totalQuantity = productHistory.Quantity;
                }

                productWithQuantities.Add(new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = totalQuantity
                });
            }

            return productWithQuantities.OrderByDescending(x => x.Quantity).ToList();
        }
    }
}
