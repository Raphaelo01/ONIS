namespace ONIS.Shared.Logger.Logs;

public class ConsoleLoggerConfiguration
{
    public bool Enabled { get; set; } = false;
    public LogEventLevel MinimumLevel { get; set; }
}
