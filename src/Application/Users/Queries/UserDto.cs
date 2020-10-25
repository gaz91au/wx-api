using System;

namespace Application.Users.Queries
{
    public class UserDto
    {
        public UserDto(string name, string token)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public string Name { get; set; }
        public string Token { get; set; }
    }
}
