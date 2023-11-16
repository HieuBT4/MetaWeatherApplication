using MetaWeatherApplication.Model;

namespace MetaWeatherApplication.Service.Interfaces
{
    public interface IOpenWeatherMapWrapper
    {
        Task<OpenWeatherMapApiResponse> GetWeatherDataAsync(string cityName);
    }
}