using Common.Model.Weather;
using Newtonsoft.Json.Linq;

namespace Common.Mapper
{
    public static class OpenWeatherMapper
    {
        public static List<WeatherLocation> WeatherLocationMapper(string datajson)
        {
            List<WeatherLocation> forecasts = new List<WeatherLocation>();
            try
            {
                JArray dataArray = JArray.Parse(datajson); // Parse as JArray
                foreach (var dataObject in dataArray)
                {
                    WeatherLocation forecast = new WeatherLocation
                    {
                        CityName = (string)dataObject["name"],
                        Country = (string)dataObject["country"],
                        Latitude = (double)dataObject["lat"],
                        Longitude = (double)dataObject["lon"]
                    };

                    forecasts.Add(forecast);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return forecasts;
        }

        public static WeatherForecast MapToWeatherForecast(string jsonData)
        {
            WeatherForecast forecast = new WeatherForecast();
            try
            {
                Dictionary<string, object> jsonDataDict = JObject.Parse(jsonData).ToObject<Dictionary<string, object>>();

                PrepareCityInfo(jsonDataDict, forecast);

                PrepateForecastItems(jsonDataDict, forecast);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return forecast;
        }

        private static void PrepateForecastItems(Dictionary<string, object> jsonDataDict, WeatherForecast forecast)
        {
            if (jsonDataDict.ContainsKey("list") && jsonDataDict["list"] is JArray forecastItemsData)
            {
                forecast.ForecastItems = new List<ForecastItem>();

                foreach (var itemData in forecastItemsData)
                {
                    PrepateForecastItem(forecast, itemData);
                }
            }
        }

        private static void PrepateForecastItem(WeatherForecast forecast, JToken itemData)
        {
            if (itemData is JObject itemDict)
            {
                ForecastItem forecastItem = new ForecastItem();
                SetWeatherDateTime(itemDict, forecastItem);
                SetTemperature(itemDict, forecastItem);
                SetWeatherInfo(itemDict, forecastItem);
                SetClouds(itemDict, forecastItem);
                SetWinds(itemDict, forecastItem);
                Setvisibility(itemDict, forecastItem);
                SetProbabilityOfPrecipitation(itemDict, forecastItem);
                SetRain(itemDict, forecastItem);
                SetSystemInformation(itemDict, forecastItem);

                forecast.ForecastItems.Add(forecastItem);
            }
        }

        private static void SetSystemInformation(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("sys", out var sysData) && sysData is JObject sysObj)
            {
                forecastItem.Sys = new SystemInfo
                {
                    Pod = sysObj.TryGetValue("pod", out var pod) ? pod.ToString() : ""
                };
            }
        }

        private static void SetRain(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("rain", out var rainData) && rainData is JObject rainObj)
            {
                if (rainObj.TryGetValue("3h", out var rainVolume))
                {
                    forecastItem.Rain = new Rainfall
                    {
                        AmountLast3Hours = Convert.ToDouble(rainVolume)
                    };
                }
            }
        }

        private static void SetProbabilityOfPrecipitation(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("pop", out var pop))
            {
                forecastItem.ProbabilityOfPrecipitation = Convert.ToDouble(pop);
            }
        }

        private static void Setvisibility(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("visibility", out var visibility))
            {
                forecastItem.Visibility = Convert.ToInt32(visibility);
            }
        }

        private static void SetWinds(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("wind", out var windData) && windData is JObject windObj)
            {
                forecastItem.Wind = new WindInfo
                {
                    Speed = windObj.TryGetValue("speed", out var speed) ? Convert.ToDouble(speed) : 0.0,
                    Degree = windObj.TryGetValue("deg", out var deg) ? Convert.ToInt32(deg) : 0,
                    Gust = windObj.TryGetValue("gust", out var gust) ? Convert.ToInt32(gust) : 0
                };
            }
        }

        private static void SetClouds(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("clouds", out var cloudsData) && cloudsData is JObject cloudsObj)
            {
                forecastItem.Clouds = new CloudCoverage
                {
                    Percentage = cloudsObj.TryGetValue("all", out var all) ? Convert.ToInt32(all) : 0
                };
            }
        }

        private static void SetWeatherInfo(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("weather", out var weatherData) && weatherData is JArray weatherArray)
            {
                if (weatherArray.Count > 0 && weatherArray[0] is JObject weatherObj)
                {
                    forecastItem.Weather = new List<WeatherInfo>
                            {
                                new WeatherInfo
                                {
                                    Description = weatherObj.TryGetValue("description", out var description) ? description.ToString() : "",
                                    Icon = weatherObj.TryGetValue("icon", out var icon) ? icon.ToString() : ""
                                }
                            };
                }
            }
        }

        private static void SetTemperature(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("main", out var mainData) && mainData is JObject mainObj)
            {
                forecastItem.Main = new MainTemperature
                {
                    Temperature = mainObj.TryGetValue("temp", out var temp) ? Convert.ToDouble(temp) : 0.0,
                    FeelsLike = mainObj.TryGetValue("feels_like", out var feelsLike) ? Convert.ToDouble(feelsLike) : 0.0,
                    TempMin = mainObj.TryGetValue("temp_min", out var tempMin) ? Convert.ToDouble(tempMin) : 0.0,
                    TempMax = mainObj.TryGetValue("temp_max", out var tempMax) ? Convert.ToDouble(tempMax) : 0.0,
                    Pressure = mainObj.TryGetValue("pressure", out var pressure) ? Convert.ToDouble(pressure) : 0.0,
                    Humidity = mainObj.TryGetValue("humidity", out var humidity) ? Convert.ToInt32(humidity) : 0,
                    GroundLevel = mainObj.TryGetValue("grnd_level", out var grnd_level) ? Convert.ToInt32(grnd_level) : 0,
                    SeaLevel = mainObj.TryGetValue("sea_level", out var sea_level) ? Convert.ToInt32(sea_level) : 0,
                    TempKf = mainObj.TryGetValue("temp_kf", out var temp_kf) ? Convert.ToInt32(temp_kf) : 0,
                };
            }
        }

        private static void SetWeatherDateTime(JObject itemDict, ForecastItem forecastItem)
        {
            if (itemDict.TryGetValue("dt", out var dtUnix))
            {
                string dt = dtUnix.ToString();
                forecastItem.DateTimeUnix = long.Parse(dt);
                forecastItem.WeatherDateTime = DateTimeOffset.FromUnixTimeSeconds(forecastItem.DateTimeUnix).DateTime;
            }
            if (itemDict.TryGetValue("dt_txt", out var dtTxt))
            {
                forecastItem.DateTimeText = dtTxt.ToString();
            }
        }

        private static void PrepareCityInfo(Dictionary<string, object> jsonDataDict, WeatherForecast forecast)
        {
            if (jsonDataDict.ContainsKey("city") && jsonDataDict["city"] is JObject cityData)
            {
                forecast.City = new CityInfo
                {
                    Name = cityData.Value<string>("name"),
                    Country = cityData.Value<string>("country"),
                    Coordinates = new Coordinates()
                    {
                        Latitude = cityData.Value<double>("lat"),
                        Longitude = cityData.Value<double>("lon"),
                    },
                    Id = cityData.Value<int>("id"),
                    Population = cityData.Value<int>("population"),
                    Sunrise = cityData.Value<int>("sunrise"),
                    Sunset = cityData.Value<int>("sunset"),
                    Timezone = cityData.Value<int>("timezone"),
                };
            }
        }
    }
}
