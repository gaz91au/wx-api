using Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserManager _userManager;

        public GetUserQueryHandler(IUserManager userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                new UserDto(_userManager.GetName(), _userManager.GetToken()));
        }
    }
}
