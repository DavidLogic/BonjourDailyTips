using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BonjourDailyTips.Models;
using BonjourDailyTips.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using BonjourDailyTips.Models.Weather;
using System.Windows.Input;

namespace BonjourDailyTips.ViewModels
{
    public partial class WeatherPageViewModel : ObservableObject
    {
        private double _latitude;
        public double Latitude
        {          
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private double _longitude;
        public double Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        private string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }
        private string _temperature;
        public string Temperature
        {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }
        private string _mintemp;
        public string MinTemperature 
        {
            get => _mintemp;
            set => SetProperty(ref _mintemp, value);
        }
        private string _maxtemp;
        public string MaxTemperature
        {
            get => _maxtemp;
            set => SetProperty(ref _maxtemp, value);
        }
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        private string _refreshedTime;
        public string RefreshedTime 
        {
            get => _refreshedTime;
            set => SetProperty(ref _refreshedTime, value);
        }

        [ObservableProperty]
        public ObservableCollection<DailyItem> dailyItems;
        [ObservableProperty]
        public ObservableCollection<HourlyItem> hourlyItems;

        private ICommand _refeshCommand { get; set; }
        public ICommand RefeshCommand 
        { get
            {
                if (_refeshCommand == null)
                {
                    _refeshCommand = new Command(LoadData);
                }
                return _refeshCommand;
            }
        }
        public WeatherPageViewModel()
        {
            LoadData();
        }

        public  async void LoadData()
        {
            IsRefreshing = true;
            //Check location permission
            var status = await GeoLocationHelper.CheckAndRequestLocationPermission();
            if (status == PermissionStatus.Granted)
            {             
                //get location
                var location = await GeoLocationHelper.GetCurrentLocation();
                Latitude = location.Latitude;
                Longitude = location.Longitude;

                //get city
                var cityInfo = await AmapHelper.GetCityData(location.Latitude, location.Longitude);
                City = cityInfo.regeocode.addressComponent.district + cityInfo.regeocode.addressComponent.township;

                //get weather
                var realTimeWeather = await QweatherHelper.GetRealTimeWeather(location.Latitude, location.Longitude);
                Temperature = realTimeWeather.now.temp;
                var dailyWeather = await QweatherHelper.GetDailyWeather(location.Latitude, location.Longitude);
                var hourlyWeather = await QweatherHelper.GetHourlyWeather(location.Latitude, location.Longitude);
                MinTemperature = dailyWeather.daily[0].tempMin;
                MaxTemperature = dailyWeather.daily[0].tempMax;
                Text = realTimeWeather.now.text;
                DailyItems = dailyWeather.daily;
                HourlyItems = hourlyWeather.hourly;
            }
            else
            {
                Temperature= ":(";
                MinTemperature = "未知";
                MaxTemperature = "未知";
                Text = "未知";
            }
            RefreshedTime = DateTime.Now.ToString("HH:mm");
            if (IsRefreshing)
            {
                IsRefreshing = false;
            }
         

        }
    }
}
