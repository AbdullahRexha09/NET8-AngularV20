using API.Services;

namespace API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddScoped<IJourneyService, JourneyService>();
            services.AddScoped<IStopService, StopService>();

            return services;
        }
    }
}
