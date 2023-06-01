using ONIS.Shared.Logger;

namespace ONIS.API.Order;
public static class HostRegistrationExtensions
{
    public static IHostBuilder RegisterHostConfigurations(this IHostBuilder host)
    {
        //Add serilog Configuration 
        host.ConfigureSerilog();
        return host;
    }
}
