using FluentValidation;

namespace Application.Products.Queries
{
    public class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
            RuleFor(x => x.SortOption)
                .NotNull().WithMessage("SortOption must not be null.")
                .NotEmpty().WithMessage("SortOption must not be empty.");
        }
    }
}
