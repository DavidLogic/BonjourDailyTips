using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BonjourDailyTips.Models.Weather
{

    public class DailyItem
    {
        public string DayOfWeek { get; set; }
        [JsonProperty("fxDate")]
        public string fxDate { get; set; }
        [JsonProperty("sunrise")]
        public string sunrise { get; set; }
        [JsonProperty("sunset")]
        public string sunset { get; set; }
        [JsonProperty("moonrise")]
        public string moonrise { get; set; }
        [JsonProperty("moonset")]
        public string moonset { get; set; }
        [JsonProperty("moonPhase")]
        public string moonPhase { get; set; }
        [JsonProperty("moonPhaseIcon")]
        public string moonPhaseIcon { get; set; }
        [JsonProperty("tempMax")]
        public string tempMax { get; set; }
        [JsonProperty("tempMin")]
        public string tempMin { get; set; }
        [JsonProperty("iconDay")]
        public string iconDay { get; set; }
        [JsonProperty("textDay")]
        public string textDay { get; set; }
        [JsonProperty("iconNight")]
        public string iconNight { get; set; }
        [JsonProperty("textNight")]
        public string textNight { get; set; }
        [JsonProperty("wind360Day")]
        public string wind360Day { get; set; }
        [JsonProperty("windDirDay")]
        public string windDirDay { get; set; }
        [JsonProperty("windScaleDay")]
        public string windScaleDay { get; set; }
        [JsonProperty("windSpeedDay")]
        public string windSpeedDay { get; set; }
        [JsonProperty("wind360Night")]
        public string wind360Night { get; set; }
        [JsonProperty("windDirNight")]
        public string windDirNight { get; set; }
        [JsonProperty("windScaleNight")]
        public string windScaleNight { get; set; }
        [JsonProperty("windSpeedNight")]
        public string windSpeedNight { get; set; }
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
        [JsonProperty("uvIndex")]
        public string uvIndex { get; set; }
    }

    public class DailyRoot
    {
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("updateTime")]
        public string updateTime { get; set; }
        [JsonProperty("fxLink")]
        public string fxLink { get; set; }
        [JsonProperty("daily")]
        public ObservableCollection<DailyItem> daily { get; set; }

    }
}
