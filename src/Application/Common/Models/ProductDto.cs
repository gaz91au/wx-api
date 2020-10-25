using AutoMapper;
using Common.Mappings;
using Domain.Entities;

namespace Application.Common.Models
{
    public class ProductDto : IMapFrom<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
        }
    }
}
