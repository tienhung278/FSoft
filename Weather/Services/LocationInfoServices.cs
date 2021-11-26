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

        public bool IsNotRainny()
        {
            return _weatherForecast.weather_descriptions.Any(t => t.ToLower() == "clear");
        }

        public bool IsHighUV()
        {
            return _weatherForecast.uv_index > 3;
        }

        public bool CanUseKite()
        {
            return IsNotRainny() && _weatherForecast.wind_speed > 15;
        }
    }
}
