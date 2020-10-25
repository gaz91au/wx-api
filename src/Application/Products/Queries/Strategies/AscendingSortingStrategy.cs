using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Products.Queries.Strategies
{
    public class AscendingSortingStrategy : ISortingStrategy
    {
        public IList<Product> Sort(IList<Product> products)
        {
            return products.OrderBy(o => o.Name).ToList();
        }
    }
}
