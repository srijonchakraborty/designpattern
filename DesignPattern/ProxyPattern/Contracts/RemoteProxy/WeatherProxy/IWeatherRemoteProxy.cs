using Common;
using Common.Model.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Contracts.RemoteProxy.WeatherProxy
{
    public interface IWeatherRemoteProxy
    {
        //Note: Currently with Free version of openweathermap I am not able to fetch date specific data
        // that is why I have used Current Date weather info using cityname and dateTime
        Task<WeatherForecast> GetCurrentWeatherInfo(DateTime dateTime,string cityName);
    }
}
