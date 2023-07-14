using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonjourDailyTips.Helpers
{
    public  class BingWallpaperHelper
    {
        public static async Task<string> GetBingWallpaperUrlAsync()
        {
            var url = "https://cn.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
            var imageUrl = obj.images[0].url;
            var fullUrl = "http://www.bing.com" + imageUrl;
            return fullUrl;
        }
    }
}
