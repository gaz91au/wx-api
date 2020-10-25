using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Queries.Strategies
{
    public class HighSortingStrategy : ISortingStrategy
    {
        public IList<Product> Sort(IList<Product> products)
        {
            if (products == null)
            {
                throw new NotFoundException(nameof(Product));
            }

            return products.OrderByDescending(o => o.Price).ToList();
        }
    }
}
