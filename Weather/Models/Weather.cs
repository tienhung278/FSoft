using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    class WeatherForecast
    {
        public string[] weather_descriptions { get; set; }
        public int uv_index { get; set; }
        public int wind_speed { get; set; }
    }
}
