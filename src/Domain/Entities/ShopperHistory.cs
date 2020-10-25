using System.Collections.Generic;

namespace Domain.Entities
{
    public class ShopperHistory
    {
        public long CustomerId { get; set; }
        public IList<Product> Products { get; set; }

    }
}
