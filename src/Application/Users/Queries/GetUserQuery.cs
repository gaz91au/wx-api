using MediatR;

namespace Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
    }
}
