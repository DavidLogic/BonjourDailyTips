using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using BonjourDailyTips.Models;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace BonjourDailyTips.Helpers
{
   
    public class AmapHelper
    {
        const string _apiKeyStr = "c267a088a081f611b4ec8dcd67369d7f";
        //Bypass SSL security check
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        public static async Task<GeoCodeRoot> GetCityData(double lat, double lon)
        {
            lat = Math.Round(lat, 6);
            lon = Math.Round(lon, 6);
            string url = $"https://restapi.amap.com/v3/geocode/regeo?output=json&location={lon},{lat}&key={_apiKeyStr}&radius=1000&extensions=all";

            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);

            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
           
            //Deserialize
            var data = JsonConvert.DeserializeObject<GeoCodeRoot>(result);

            return data;
        }
    }
}
