using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using BonjourDailyTips.Helpers;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BonjourDailyTips.ViewModels
{
    public  class TodayPageViewModel:ObservableObject 
    {
        //今天的日期
        private string _todayDate;
        public string TodayDate
        {
            get => _todayDate;
            set => SetProperty(ref _todayDate, value);
        }

        //今天的星期
        private string _todayWeek;
        public string TodayWeek
        {
            get => _todayWeek;
            set => SetProperty(ref _todayWeek, value);
        }


        //提示早晚
        private string _Timetips;
        public string Timetips
        {
            get => _Timetips;
            set => SetProperty(ref _Timetips, value);
        }
       

        private string _bingPicUrl ;
        public string BingPicUrl
        {
            get => _bingPicUrl;
            set => SetProperty(ref _bingPicUrl, value);
        }
        public  TodayPageViewModel() 
        {
            CultureInfo chineseCulture = new CultureInfo("zh-CN");

            // 获取星期几的枚举值
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;

            // 获取中文工作日名称
            string chineseWeekdayName = chineseCulture.DateTimeFormat.GetDayName(dayOfWeek);
            this.TodayWeek = chineseWeekdayName;
            this.TodayDate = DateTime.Now.ToString("yyyy年MM月dd日")+","+TodayWeek;
            
            //获取早晚提示
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12)
            {
                this.Timetips = "早上好";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                this.Timetips = "下午好";
            }
            else
            {
                this.Timetips = "晚上好";
            }
            //获取必应壁纸
            TriggerBingPicUrl();

        }
        private async void TriggerBingPicUrl()
        {
            this.BingPicUrl = await BingWallpaperHelper.GetBingWallpaperUrlAsync();
        }
    }
}
