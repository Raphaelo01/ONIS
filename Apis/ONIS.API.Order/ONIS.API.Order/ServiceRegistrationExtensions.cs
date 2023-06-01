using Microsoft.EntityFrameworkCore;
using ONIS.Business.Order.Interfaces;
using ONIS.Business.Order.Services;
using ONIS.Data.Order.Context;
using ONIS.Data.Order.Services.Interfaces;
using ONIS.Data.Order.Services.Repositories;
using Serilog;

namespace ONIS.API.Order;

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
        services.AddDbContext<OrdersDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderDB")));
        //RegisterBusiness
        services.AddScoped<IOrderServices, OrderServices>();
        services.AddScoped<IOrderItemServices, OrderItemServices>();
        // register the repository
        services.AddScoped<IOrderRepository, OrderRepository>();
        // register the repository
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        //AddSerilog
        services.AddLogging(logger => logger.AddSerilog());

        return services;
    }
}

