using Application.Common.Enums;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Options;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Queries.Strategies
{
    public class RecommendedProductsQuery : IProductQuery
    {
        private readonly IProductsApi _productsApi;

        public RecommendedProductsQuery(IProductsApi productsApi)
        {
            _productsApi = productsApi ?? throw new ArgumentNullException(nameof(productsApi));
        }

        public ProductQueryOptions QueryOptions => new ProductQueryOptions
        {
            SortOption = SortOption.Recommended
        };

        public async Task<IList<Product>> GetProducts()
        {
            var allProducts = await _productsApi.GetProductListAsync();

            var shopperHistories = await _productsApi.GetShopperHistoryAsync();

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
                                            
            var recommendedProducts = new List<Product>();

            foreach (var product in allProducts)
            {
                var totalQuantity = 0m;

                var productHistory = groupedPurchasedProducts.FirstOrDefault(s => s.Name == product.Name);

                if (productHistory != null)
                {
                    totalQuantity = productHistory.Quantity;
                }
                
                recommendedProducts.Add(new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = totalQuantity
                });
            }

            return recommendedProducts.OrderByDescending(x => x.Quantity).ToList();
        }
    }
}
