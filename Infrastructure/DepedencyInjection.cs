using Domain.Interfaces;
using Infrastructure.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            
            return services;
        }
    }
}
