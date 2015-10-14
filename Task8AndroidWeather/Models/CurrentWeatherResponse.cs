using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8AndroidWeather.Models
{
    public class CurrentWeatherResponse
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        
    }
}