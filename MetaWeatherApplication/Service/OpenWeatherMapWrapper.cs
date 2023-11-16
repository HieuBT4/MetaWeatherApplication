using MetaWeatherApplication.Model;
using MetaWeatherApplication.Service.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace MetaWeatherApplication.Service
{
    public class OpenWeatherMapWrapper : IOpenWeatherMapWrapper
    {
        private readonly ApiSettings _apiSettings;
        private readonly ILogger<OpenWeatherMapWrapper> _logger;

        public OpenWeatherMapWrapper(IOptions<ApiSettings> apiSettings, ILogger<OpenWeatherMapWrapper> logger)
        {
            _apiSettings = apiSettings.Value;
            _logger = logger;
        }

        public async Task<OpenWeatherMapApiResponse> GetWeatherDataAsync(string cityName)
        {
            OpenWeatherMapApiResponse? openWeatherMapApiResponse = null;
            _logger.LogInformation($"Start {nameof(GetWeatherDataAsync)}");
            try
            {
                var url =$"{_apiSettings.OpenWeatherMapApiUrl}?q={cityName}&appid={_apiSettings.OpenWeatherMapApiKey}";

                _logger.LogInformation($"Sending request to {url}");

                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    openWeatherMapApiResponse = JsonConvert.DeserializeObject<OpenWeatherMapApiResponse>(response);

                    _logger.LogInformation($"Reponse : {response}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred: {ex.Message}");
            }
            _logger.LogInformation($"End {nameof(GetWeatherDataAsync)}");

            return openWeatherMapApiResponse;
        }
    }
}
