﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Sharpnado.Tabs;
using Material.Components.Maui.Extensions;
namespace BonjourDailyTips;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMaterialComponents(new List<string> { "OpenSans-Regular.ttf" , "OpenSans-Semibold.ttf" })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
        events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));
 
        static void MakeStatusBarTranslucent(Android.App.Activity activity)
        {
            activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);
 
            activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
 
            activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        }
#endif
            })

            .UseSharpnadoTabs(loggerEnable: false);

#if DEBUG
		builder.Logging.AddDebug();
#endif


        return builder.Build();
	}
}
