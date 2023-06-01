using Microsoft.EntityFrameworkCore;
using ONIS.Business.Basket.Interfaces;
using ONIS.Business.Basket.Services;
using ONIS.Data.Basket.Context;
using ONIS.Data.Basket.Services.Interfaces;
using ONIS.Data.Basket.Services.Repositories;
using Serilog;

namespace ONIS.API.Basket;


public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterBusinessServices(
           this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        // add the DbContext
        services.AddDbContext<BasketDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("BasketDB")));
        //RegisterBusiness
        services.AddScoped<IBasketServices, BasketServices>();
        services.AddScoped<IBasketItemService, BasketItemServices>();
        // register the repository
        services.AddScoped<IBasketRepository, BasketRepository>();
        // register the repository
        services.AddScoped<IBasketItemRepository, BasketItemRepository>();
        //AddSerilog
        services.AddLogging(logger => logger.AddSerilog());

        return services;
    }
}


