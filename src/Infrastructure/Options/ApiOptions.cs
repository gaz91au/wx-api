using System;

namespace Infrastructure.Options
{
    public class ApiOptions
    {
        public ApiOptions(string uri)
        {
            BaseUri = new Uri(uri) ?? throw new ArgumentNullException(nameof(uri));
        }

        public Uri BaseUri { get; set; }
    }
}
