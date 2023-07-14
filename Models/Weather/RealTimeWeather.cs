using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BonjourDailyTips.Models.Weather
{

    public class Now
    {
       [JsonProperty("obsTime")]
        public string obsTime { get; set; }
       [JsonProperty("temp")]
        public string temp { get; set; }
       [JsonProperty("feelsLike")]
        public string feelsLike { get; set; }
       [JsonProperty("icon")]
        public string icon { get; set; }
       [JsonProperty("text")]
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
       [JsonProperty("precip")]
        public string precip { get; set; }
       [JsonProperty("pressure")]
        public string pressure { get; set; }
       [JsonProperty("vis")]
        public string vis { get; set; }
       [JsonProperty("cloud")]
        public string cloud { get; set; }
       [JsonProperty("dew")]
        public string dew { get; set; }
    }


    public class RealTimeRoot
    {
       [JsonProperty("code")]
        public string code { get; set; }
       [JsonProperty("updateTime")]
        public string updateTime { get; set; }
       [JsonProperty("fxLink")]
        public string fxLink { get; set; }
       [JsonProperty("now")]
        public Now now { get; set; }

    }
}
