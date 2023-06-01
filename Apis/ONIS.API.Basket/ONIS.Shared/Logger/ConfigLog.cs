using ONIS.Shared.Logger.GrayLConfiguration;

namespace ONIS.Shared.Logger;

public static class ConfigLog
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
   => builder.UseSerilog((context, loggerConfiguration)
       => ConfigureSerilogLogger(loggerConfiguration, context.Configuration));

    private static LoggerConfiguration ConfigureSerilogLogger(LoggerConfiguration loggerConfiguration,
        IConfiguration configuration)
    {
        GraylogLoggerConfiguration graylogLogger = new GraylogLoggerConfiguration();
        configuration.GetSection("Logging:Graylog").Bind(graylogLogger);
        ConsoleLoggerConfiguration consoleLogger = new ConsoleLoggerConfiguration();
        configuration.GetSection("Logging:Console").Bind(consoleLogger);

        return loggerConfiguration
                .AddConsoleLogger(consoleLogger)
                .AddGraylogLogger(graylogLogger);
    }
}
