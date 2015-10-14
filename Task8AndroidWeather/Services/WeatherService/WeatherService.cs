using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task8AndroidWeather.Models;
using Task8AndroidWeather.Services.Networking;

namespace Task8AndroidWeather.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly IRestClient _restClient = new RestClient();

        private string ApiKey = "160619e1fc4f428920b7c7f32090311d";


        public async Task<Main> GetForcastByDate(string cityName, DateTime date)
        {
            string uri = GetFullForcastUri(cityName);
            var responce = await _restClient.GetAsync(uri);
            var fResponse = JsonConvert.DeserializeObject<ForecastResponse>(responce);
            List forecast;
            try
            {
                forecast =
                    fResponse.list.Where(f => (Convert.ToDateTime(f.dt_txt).Day == date.Day)).Select(f => f).First();
            }
            catch (Exception)
            {
                return null;
            }

            return forecast.main;
        }

        public async Task<CurrentWeather> GetCurrentWeather(string cityName)
        {
            string uri = GetFullCurrentWeathertUri(cityName);
            var responce = await _restClient.GetAsync(uri);
            var cwResponse = JsonConvert.DeserializeObject<CurrentWeatherResponse>(responce);
            CurrentWeather currentWeather = new CurrentWeather(cwResponse.weather.Select(f => f).First().description,
                cwResponse.main);
            return currentWeather;
        }

        private string GetFullForcastUri(string cityName)
        {
            return String.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID={1}&units=metric",
                cityName, ApiKey);
        }

        private string GetFullCurrentWeathertUri(string cityName)
        {
            return String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric&cnt=1",
                cityName, ApiKey);
        }
    }
}