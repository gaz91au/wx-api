using Application.Common.Enums;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Options;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IList<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEnumerable<IProductQuery> _productQueries;


        public GetProductListQueryHandler(IMapper mapper, IEnumerable<IProductQuery> productQueries)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productQueries = productQueries ?? throw new ArgumentNullException(nameof(productQueries));
        }

        public async Task<IList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            if (Enum.TryParse(request.SortOption, true , out SortOption sortOption) == false)
            {
                throw new NotSupportedException($"Sort Option: {request.SortOption} is not supported.");
            };

            var queryOptions = new ProductQueryOptions
            {
                SortOption = sortOption
            };

            var query = _productQueries.FirstOrDefault(x => x.QueryOptions.Equals(queryOptions));

            var products = await query.GetProducts();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
