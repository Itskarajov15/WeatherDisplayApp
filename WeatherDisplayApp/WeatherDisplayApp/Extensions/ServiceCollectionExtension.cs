using WeatherDisplayApp.ExceptionHandling;
using WeatherDisplayApp.Services.Contracts;
using WeatherDisplayApp.Services.Services;

namespace WeatherDisplayApp.Extensions;

public static class SharedTripServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        services.AddHttpClient();
        services.AddTransient<IWeatherService, WeatherService>();

        return services;
    }
}