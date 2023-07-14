using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BonjourDailyTips;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Sensor,ResizeableActivity = true,RotationAnimation = Android.Views.WindowRotationAnimation.Rotate, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}
