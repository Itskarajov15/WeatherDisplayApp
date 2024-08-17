using Serilog;

namespace WeatherDisplayApp.Extensions;

public static class SerilogConfigurationExtension
{
    public static void ConfigureSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });
    }
}