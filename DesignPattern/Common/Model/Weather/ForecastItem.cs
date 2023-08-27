using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Weather
{
    public class ForecastItem
    {
        public long DateTimeUnix { get; set; }
        public DateTime WeatherDateTime { get; set; }
        public MainTemperature Main { get; set; }
        public List<WeatherInfo> Weather { get; set; }
        public CloudCoverage Clouds { get; set; }
        public WindInfo Wind { get; set; }
        public int Visibility { get; set; }
        public double ProbabilityOfPrecipitation { get; set; }
        public Rainfall Rain { get; set; }
        public SystemInfo Sys { get; set; }
        public string DateTimeText { get; set; }
    }
}
