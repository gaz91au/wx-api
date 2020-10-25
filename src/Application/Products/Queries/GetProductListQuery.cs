using Application.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Products.Queries
{
    public class GetProductListQuery : IRequest<IList<ProductDto>>
    {
        public string SortOption { get; set; }
    }
}
