using Application.Common.Options;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductQuery
    {
        public ProductQueryOptions QueryOptions { get; }
        Task<IList<Product>> GetProducts();
    }
}
