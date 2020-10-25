using Application.Common.Interfaces;
using Infrastructure.Api;
using Infrastructure.Identity;
using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddSingleton(_ => 
                new UserOptions(configuration["User:Name"], configuration["User:Token"]));

            services.AddSingleton(_ =>
                new ApiOptions(configuration["WoolworthsApi:BaseUri"]));

            services.AddSingleton<IUserManager, UserManager>();

            services.AddScoped<IProductsApi, WoolworthsApiClient>();
            
            return services;
        }
    }
}
