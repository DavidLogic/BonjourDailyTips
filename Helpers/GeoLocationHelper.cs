using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
#if ANDROID
using Android.Webkit;
#endif
using Microsoft.Maui.Devices.Sensors;


namespace BonjourDailyTips.Helpers
{
    public class GeoLocationHelper
    {
        private static CancellationTokenSource _cancelTokenSource;
        private static bool _isCheckingLocation;
        public static async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied )
            {
                
                await Snackbar.Make("Location permission is needed to show current location.").Show();

                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                /*
                 在某些平台上，权限请求只能激活一次,必须处理进一步的提示，以检查权限是否处于 状态Denied，然后要求用户手动将其打开。*/
                //if (status != PermissionStatus.Granted)
                //{
                //    AppInfo.Current.ShowSettingsUI();
                //}

            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
               await  Snackbar.Make("Location permission is needed to show current location.").Show();
            }


            return status;
        }


        public async static Task<Location> GetCurrentLocation()
        {
            try
            {

                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();
                //当用户拒绝位置权限阻止应用程序退出


                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
                return location;
            }

            finally {
                _isCheckingLocation = false;
               
            } 


        }



        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            {
                _cancelTokenSource.Cancel(false);
            }
        }
    }
}

