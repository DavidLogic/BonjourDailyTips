using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BonjourDailyTips.Models
{
    
    public class ImagesItem
    {
        [JsonProperty(nameof(startdate))]
        public string startdate { get; set; }

        [JsonProperty(nameof(fullstartdate))]
        public string fullstartdate { get; set; }

        [JsonProperty(nameof(enddate))]
        public string enddate { get; set; }

        [JsonProperty(nameof(url))]
        public string url { get; set; }
        [JsonProperty(nameof(urlbase))]
        public string urlbase { get; set; }
        [JsonProperty(nameof(copyright))]

        public string copyright { get; set; }
        [JsonProperty(nameof(copyrightlink))]

        public string copyrightlink { get; set; }

        public string title { get; set; }

        public string quiz { get; set; }

        public string wp { get; set; }

        public string hsh { get; set; }

        public int drk { get; set; }

        public int top { get; set; }

        public int bot { get; set; }

        public List<string> hs { get; set; }
    }


    public class Root
    {

        public List<ImagesItem> images { get; set; }

    }
}
