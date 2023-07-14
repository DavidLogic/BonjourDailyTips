using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BonjourDailyTips.Models.Weather
{


    public class HourlyItem
    {
        [JsonProperty("temp")]
        public string temp { get; set; }
        [JsonProperty("icon")]
        public string icon { get; set; }
        [JsonProperty(nameof(text))]
        public string text { get; set; }
        [JsonProperty("wind360")]
        public string wind360 { get; set; }
        [JsonProperty("windDir")]
        public string windDir { get; set; }
        [JsonProperty("windScale")]
        public string windScale { get; set; }
        [JsonProperty("windSpeed")]
        public string windSpeed { get; set; }
        [JsonProperty("humidity")]
        public string humidity { get; set; }
        [JsonProperty("pop")]
        public string pop { get; set; }
        [JsonProperty("precip")]
        public string precip { get; set; }
        [JsonProperty("pressure")]
        public string pressure { get; set; }
        [JsonProperty("cloud")]
        public string cloud { get; set; }
        [JsonProperty("dew")]
        public string dew { get; set; }
        [JsonProperty(nameof(fxTime))]
        public string fxTime { get; set; }
    }


    public class HourlyRoot
    {
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("updateTime")]
        public string updateTime { get; set; }
        [JsonProperty("fxLink")]
        public string fxLink { get; set; }
        [JsonProperty("hourly")]
        public ObservableCollection<HourlyItem> hourly { get; set; }
    }
}
