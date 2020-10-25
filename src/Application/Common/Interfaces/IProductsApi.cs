using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductsApi
    {
        Task<IList<Product>> GetProductListAsync();
        Task<IList<ShopperHistory>> GetShopperHistoryAsync();
    }
}
