using Domain.Entities;
using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface ISortingStrategy
    {
        IList<Product> Sort(IList<Product> products);
    }
}
