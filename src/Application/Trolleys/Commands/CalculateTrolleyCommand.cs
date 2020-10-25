using MediatR;
using System.Collections.Generic;

namespace Application.Trolleys.Commands
{
    public class CalculateTrolleyCommand : IRequest<decimal>
    {
        public IList<Product> Products { get; set; }
        public IList<Special> Specials { get; set; }
        public IList<Quantities> Quantities { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class Quantities // Renamed from "Quantity" to "Quantities" because member names cannot be the same as their enclosing type (CS0542).
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class Special
    {
        public List<Quantities> Quantities { get; set; }
        public int Total { get; set; }
    }
}
