using System;
using System.Threading.Tasks;
using Task8AndroidWeather.Models;

namespace Task8AndroidWeather.Services.WeatherService
{
    public interface IWeatherService
    {
        Task<Main> GetForcastByDate(string cityName, DateTime date);
        Task<CurrentWeather> GetCurrentWeather(string cityName);
    }
}