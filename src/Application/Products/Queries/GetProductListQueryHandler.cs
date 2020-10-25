using Application.Common.Enums;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IList<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsApi _productsApi;
        private readonly ISortingStrategyFactory _sortingStrategyFactory;

        public GetProductListQueryHandler(IMapper mapper, IProductsApi productsApi, ISortingStrategyFactory sortingStrategyFactory)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productsApi = productsApi ?? throw new ArgumentNullException(nameof(productsApi));
            _sortingStrategyFactory = sortingStrategyFactory ?? throw new ArgumentNullException(nameof(sortingStrategyFactory));
        }

        public async Task<IList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            if (Enum.TryParse(request.SortOption, true , out SortOption sortOption) == false)
            {
                throw new NotSupportedException($"Sort Option: {request.SortOption} is not supported.");
            };

            var products = await _productsApi.GetProductListAsync();

            if (products == null)
            {
                throw new NotFoundException(nameof(Product));
            }

            var strategy = _sortingStrategyFactory.GetStrategy(sortOption);

            var sorted = strategy.Sort(products);

            return _mapper.Map<List<ProductDto>>(sorted);
        }
    }
}
