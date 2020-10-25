using Application.Common.Interfaces;
using Application.UnitTests.Common.Fixtures;
using Application.Users.Queries;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Users.Queries
{
    public class GetUserQueryHandlerTests : IClassFixture<TestFixture>
    {
        private readonly IUserManager _userManager;

        public GetUserQueryHandlerTests(TestFixture fixture)
        {
            _userManager = fixture.UserManager;
        }

        [Fact]
        public async Task GivenValidRequest_ShouldReturnCorrectResponse()
        {
            // Arrange
            var query = new GetUserQuery();
            var handler = new GetUserQueryHandler(_userManager);

            // Act
            var response = await handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<UserDto>();
            response.Name.Should().Be(_userManager.GetName());
            response.Token.Should().Be(_userManager.GetToken());
        }
    }
}
