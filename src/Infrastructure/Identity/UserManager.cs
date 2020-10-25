using Application.Common.Interfaces;
using Infrastructure.Options;
using System;

namespace Infrastructure.Identity
{
    public class UserManager : IUserManager
    {
        private readonly UserOptions _userOptions;

        public UserManager(UserOptions userOptions)
        {
            _userOptions = userOptions ?? throw new ArgumentNullException(nameof(UserOptions));
        }

        public string GetName() => _userOptions.Name;

        public string GetToken() => _userOptions.Token;
    }
}
