using Microsoft.EntityFrameworkCore;
using ONIS.Bussines.Catalog.Interfaces;
using ONIS.Bussines.Catalog.Services;
using ONIS.Data.Catalog.Context;
using ONIS.Data.Catalog.Services.Interfaces;
using ONIS.Data.Catalog.Services.Repositories;
using Serilog;

namespace ONIS.API.Catalog;

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
        // add the DbContext
        services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogDB")));

        //RegisterBusiness
        services.AddScoped<IProductService, ProductService>();
        // register the repository
        services.AddScoped<IProductCatalogRepository, ProductCatalogRepository>();

        //AddSerilog
        services.AddLogging(logger => logger.AddSerilog());




        return services;
    }
}

