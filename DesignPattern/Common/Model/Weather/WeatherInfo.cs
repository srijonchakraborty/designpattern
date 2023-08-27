using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Weather
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Rainfall
    {
        public double? AmountLast3Hours { get; set; }
    }

    public class SystemInfo
    {
        public string Pod { get; set; }
    }
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
