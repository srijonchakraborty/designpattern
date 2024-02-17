using Common.Mapper;
using Common.Model.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ProxyPattern.Contracts.RemoteProxy.WeatherProxy;

namespace ProxyPattern.Implementation.RemoteProxy.WeatherProxy
{
    public class WeatherRemoteProxy : IWeatherRemoteProxy
    {
        public async Task<WeatherForecast> GetCurrentWeatherInfo(DateTime dateTime, string cityName)
        {
            WeatherForecast weatherweatherForecast = new WeatherForecast();
            var forecasts = await GetCurrentWeatherLocation(cityName);
            if (forecasts != null && forecasts.Count > 0)
            {
                var fullweather = await GetWeatherForecast(forecasts[0]);
                var greaterThanGivenDT = fullweather.ForecastItems.FirstOrDefault(c => c.WeatherDateTime >= dateTime);
                var lessThanGivenDT = fullweather.ForecastItems.FirstOrDefault(c => c.WeatherDateTime <= dateTime);

                TimeSpan? diff1 = greaterThanGivenDT?.WeatherDateTime - dateTime;
                TimeSpan? diff2 = dateTime - lessThanGivenDT?.WeatherDateTime;
                FinalizeWeatherInfo(fullweather, greaterThanGivenDT, lessThanGivenDT, diff1, diff2);
                weatherweatherForecast = fullweather;
            }
            return weatherweatherForecast;
        }
        private static void FinalizeWeatherInfo(WeatherForecast fullweather, ForecastItem? greaterThanGivenDT, ForecastItem? lessThanGivenDT, TimeSpan? diff1, TimeSpan? diff2)
        {
            if ((diff1?.Seconds ?? 0) < (diff2?.Seconds ?? 0))
            {
                UpdateForecastItems(fullweather, greaterThanGivenDT);
            }
            else
            {
                UpdateForecastItems(fullweather, lessThanGivenDT);
            }
        }
        private static void UpdateForecastItems(WeatherForecast fullweather, ForecastItem? selectedDate)
        {
            if (selectedDate != null)
            {
                fullweather.ForecastItems = fullweather?.ForecastItems?.Where(c => c.WeatherDateTime == selectedDate.WeatherDateTime)?.ToList() ?? new List<ForecastItem>();
            }
            else
            {
                fullweather.ForecastItems = new List<ForecastItem>();
            }
        }
        private static async Task<WeatherForecast> GetWeatherForecast(WeatherLocation weatherLocation)
        {

            WeatherForecast forecast = new WeatherForecast();
            if (weatherLocation == null)
                return forecast;
            string apiUrl = $"http://api.openweathermap.org/data/2.5/forecast?lat={weatherLocation.Latitude}&lon={weatherLocation.Longitude}&appid={Constants.ApiKey}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    forecast = OpenWeatherMapper.MapToWeatherForecast(json);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }

            return forecast;
        }
        private static async Task<List<WeatherLocation>> GetCurrentWeatherLocation(string cityName)
        {
            string apiUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit={5}&appid={Constants.ApiKey}";
            List<WeatherLocation> forecasts = new List<WeatherLocation>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    forecasts = OpenWeatherMapper.WeatherLocationMapper(json);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            return forecasts;
        }
    }
}
