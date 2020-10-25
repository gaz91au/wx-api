using System;

namespace Infrastructure.Options
{
    public class UserOptions
    {
        public UserOptions(string name, string token)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public string Name { get; set; }
        public string Token { get; set; }
    }
}
