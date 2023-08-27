using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Weather
{
    public class WeatherForecast
    {
        public string ResponseCode { get; set; }
        public int Message { get; set; }
        public int ForecastItemCount { get; set; }
        public List<ForecastItem> ForecastItems { get; set; }
        public CityInfo City { get; set; }
    }
}
