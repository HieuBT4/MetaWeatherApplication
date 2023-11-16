using MetaWeatherApplication.Model;
using MetaWeatherApplication.Service;
using MetaWeatherApplication.Service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MetaWeatherApplication
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOpenWeatherMapWrapper, OpenWeatherMapWrapper>();
        }
    }
}
