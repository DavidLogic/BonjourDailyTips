using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using BonjourDailyTips.Models.Weather;
using System.Globalization;

namespace BonjourDailyTips.Helpers
{
    public class QweatherHelper
    {
        const string _apiKeyStr = "77f152c854df453bb27155a7a2417e34";
        //Bypass SSL security check
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        public async static Task<HourlyRoot> GetHourlyWeather(double lat, double lon)
    {

        //限制lat，lon的精度，否则会报错
            lat = Math.Round(lat, 2);
            lon = Math.Round(lon, 2);

            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            var http = new HttpClient(handler);
            var response = await http.GetAsync($"https://devapi.qweather.com/v7/weather/24h?location={lon},{lat}&key={_apiKeyStr}");

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<HourlyRoot>(result);
            foreach (var item in data.hourly)
            {
                string originalDateTimeString = item.fxTime;
                DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(originalDateTimeString);

                item.fxTime = dateTimeOffset.ToString("HH:mm");
                
            }
            return data;
    }

        public async static Task<RealTimeRoot> GetRealTimeWeather(double lat, double lon) 
        {
            //限制lat，lon的精度，否则会报错
            lat = Math.Round(lat, 2);
            lon = Math.Round(lon, 2);

            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };

            var http = new HttpClient(handler);
            string url = $"https://devapi.qweather.com/v7/weather/now?location={lon},{lat}&key={_apiKeyStr}";
            var response = await http.GetAsync(url);
           
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RealTimeRoot>(result);

            return data;
        }

        public async static Task<DailyRoot> GetDailyWeather(double lat, double lon)
        {

            //限制lat，lon的精度，否则会报错
            lat = Math.Round(lat, 2);
            lon = Math.Round(lon, 2);

            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            var http = new HttpClient(handler);
            string url = $"https://devapi.qweather.com/v7/weather/7d?location={lon},{lat}&key={_apiKeyStr}";
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<DailyRoot>(result);
            
            foreach (var item in data.daily)
            {
                // 创建用于中文（简体）的 CultureInfo 对象
                CultureInfo chineseCulture = new CultureInfo("zh-CN");

                // 获取 item 的日期
                DateTime itemDate = DateTime.Parse(item.fxDate);

                // 获取星期几的枚举值
                DayOfWeek dayOfWeek = itemDate.DayOfWeek;

                // 获取中文工作日名称
                string chineseWeekdayName = chineseCulture.DateTimeFormat.GetDayName(dayOfWeek);

                // 将中文工作日名称设置给项的 DayOfWeek 属性
                data.daily[data.daily.IndexOf(item)].DayOfWeek = chineseWeekdayName;
                data.daily[data.daily.IndexOf(item)].fxDate = DateTime.Parse(item.fxDate).ToString("MM月dd日");
                
            }
            return data;
        }


    }

}
