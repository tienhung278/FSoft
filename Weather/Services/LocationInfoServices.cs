using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Contracts;
using Weather.Models;

namespace Weather.Services
{
    class LocationInfoServices
    {
        private readonly ILocationInfoRepository _locationRepository;
        private WeatherForecast _weatherForecast;

        public int ZipCode 
        {
            set
            {
                GetWeatherForecast(value);
            }
        }

        public LocationInfoServices(ILocationInfoRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        private void GetWeatherForecast(int zipcode)
        {
            var param = string.Format("query={0}", zipcode);
            _weatherForecast = _locationRepository.GetLocationInfoByZipCode(param)?.current;
        }

        private bool IsRainny()
        {
            return _weatherForecast.weather_descriptions.Any(t => t.ToLower().Contains("rain"));
        }

        private bool IsHighUV()
        {
            return _weatherForecast.uv_index > 3;
        }

        private bool CanUseKite()
        {
            return !IsRainny() && _weatherForecast.wind_speed > 15;
        }

        public string GetAnswer(int option)
        {
            string answer = string.Empty;

            switch (option)
            {
                case 1:
                    answer = IsRainny() ? "No" : "Yes";
                    break;
                case 2:
                    answer = IsHighUV() ? "Yes" : "No";
                    break;
                case 3:
                    answer = CanUseKite() ? "Yes" : "No";
                    break;
                default:
                    answer = "Sorry, I cannot understand your question!";
                    break;
            }

            return answer;
        }
    }
}
