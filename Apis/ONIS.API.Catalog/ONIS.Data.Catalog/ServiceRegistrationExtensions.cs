using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ONIS.Data.Catalog;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterBusinessServices(
            this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection RegisterDataServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        // add the DbContext

        return services;
    }
}