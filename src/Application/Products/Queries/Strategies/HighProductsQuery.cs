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
    public class HighProductsQuery : IProductQuery
    {
        private readonly IProductsApi _productsApi;

        public HighProductsQuery(IProductsApi productsApi)
        {
            _productsApi = productsApi ?? throw new ArgumentNullException(nameof(productsApi));
        }

        public ProductQueryOptions QueryOptions => new ProductQueryOptions
        {
            SortOption = SortOption.High
        };

        public async Task<IList<Product>> GetProducts()
        {
            var products = await _productsApi.GetProductListAsync();

            if (products == null)
            {
                throw new NotFoundException(nameof(Product));
            }

            return products.OrderByDescending(o => o.Price).ToList();
        }
    }
}
