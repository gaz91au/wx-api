using Application.Products.Queries;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.Products.Queries
{
    public class GetProductListQueryValidatorTests
    {
        private readonly GetProductListQueryValidator _validator;

        public GetProductListQueryValidatorTests()
        {
            _validator = new GetProductListQueryValidator();
        }

        [Fact]
        public void GivenEmptySortOption_ShouldHave_ValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.SortOption, string.Empty);
        }
    }
}
