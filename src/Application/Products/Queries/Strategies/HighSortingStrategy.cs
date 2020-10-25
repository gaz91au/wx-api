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
            return products.OrderByDescending(o => o.Price).ToList();
        }
    }
}
