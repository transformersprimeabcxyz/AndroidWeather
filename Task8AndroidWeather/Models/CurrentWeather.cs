using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8AndroidWeather.Models
{
    public class CurrentWeather
    {
        public string description { get; set; }
        public Main main { get; set; }
        

        public CurrentWeather(string description, Main main)
        {
            this.description = description;
            this.main = main;
            
        }
    }

   
}