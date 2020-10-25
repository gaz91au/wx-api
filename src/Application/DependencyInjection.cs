using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.Products.Queries.Strategies;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IProductQuery, AscendingProductsQuery>();
            services.AddScoped<IProductQuery, DescendingProductsQuery>();
            services.AddScoped<IProductQuery, HighProductsQuery>();
            services.AddScoped<IProductQuery, LowProductsQuery>();
            services.AddScoped<IProductQuery, RecommendedProductsQuery>();

            return services;
        }
    }
}
