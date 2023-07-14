using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BonjourDailyTips.Models
{


    public class AddressComponent
    {
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("province")]
        public string province { get; set; }
        [JsonProperty("adcode")]
        public string adcode { get; set; }
        [JsonProperty("district")]
        public string district { get; set; }
        [JsonProperty("towncode")]
        public string towncode { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("township")]
        public string township { get; set; }

        [JsonProperty("citycode")]
        public string citycode { get; set; }
    }

    public class Regeocode
    {
        [JsonProperty("addressComponent")]
        public AddressComponent addressComponent { get; set; }
        [JsonProperty("formatted_address")]
        public string formatted_address { get; set; }
    }
    [DataContract]
    public class GeoCodeRoot
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("regeocode")]
        public Regeocode regeocode { get; set; }
        [JsonProperty("info")]
        public string info { get; set; }
        [JsonProperty("infocode")]
        public string infocode { get; set; }
    }
}
