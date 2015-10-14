using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Task8AndroidWeather.Models;
using Task8AndroidWeather.Services.WeatherService;

namespace Task8AndroidWeather
{
    [Activity(Label = "Task8AndroidWeather", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private IWeatherService _weatherService = new WeatherService();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.SearchButton);

            button.Click += OnSearchButtonClickedAsync;
        }

        private async void OnSearchButtonClickedAsync(object sender, EventArgs e)
        {
            try
            {
                string cityName = FindViewById<EditText>(Resource.Id.CityName).Text;

                var now = DateTime.Now;
                TextView currentDateTime = FindViewById<TextView>(Resource.Id.CurrentDateTime);
                currentDateTime.Text = now.ToString("dd - MM - yy  HH.mm");
                TextView secondDate = FindViewById<TextView>(Resource.Id.SecondDate);
                secondDate.Text = now.AddDays(1).ToString("dd-MM-yy");
                TextView thirdDate = FindViewById<TextView>(Resource.Id.ThirdDate);
                thirdDate.Text = now.AddDays(2).ToString("dd-MM-yy");


                var cw = await _weatherService.GetCurrentWeather(cityName);
                CurrentWeather currentWeather = cw;

                FindViewById<TextView>(Resource.Id.Description).Text = currentWeather.description;
                FindViewById<TextView>(Resource.Id.CurrentTemperature).Text = String.Format("{0} C",
                    currentWeather.main.temp);
                FindViewById<TextView>(Resource.Id.MinTemperature).Text = String.Format("min {0} C",
                    currentWeather.main.temp_min);
                FindViewById<TextView>(Resource.Id.MaxTemperature).Text = String.Format("max {0} C",
                    currentWeather.main.temp_max);
                FindViewById<TextView>(Resource.Id.Humidity).Text = String.Format("humidity {0} %",
                    currentWeather.main.humidity);


                var sdm = await _weatherService.GetForcastByDate(cityName, DateTime.Now.AddDays(1));
                Main secondDayMain = sdm;

                FindViewById<TextView>(Resource.Id.SecondDateMinTemperature).Text = String.Format("min {0} C",
                    secondDayMain.temp_min);
                FindViewById<TextView>(Resource.Id.SecondDateMaxTemperature).Text = String.Format("max {0} C",
                    secondDayMain.temp_max);
                FindViewById<TextView>(Resource.Id.SecondDateHumidity).Text = String.Format("humidity {0} %",
                    secondDayMain.humidity);


                var tdm = await _weatherService.GetForcastByDate(cityName, DateTime.Now.AddDays(2));
                Main thirdDayMain = tdm;

                FindViewById<TextView>(Resource.Id.ThirdDateMinTemperature).Text = String.Format("min {0} C",
                    thirdDayMain.temp_min);
                FindViewById<TextView>(Resource.Id.ThirdDateMaxTemperature).Text = String.Format("max {0} C",
                    thirdDayMain.temp_max);
                FindViewById<TextView>(Resource.Id.ThirdDateHumidity).Text = String.Format("humidity {0} %",
                    thirdDayMain.humidity);
            }
            catch 
            {
                
            }
        }
    }
}