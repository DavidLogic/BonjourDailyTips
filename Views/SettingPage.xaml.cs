namespace BonjourDailyTips.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
	}

    async private void Button_Clicked(object sender, EventArgs e)
    {
        Uri uri = new Uri("https://github.com/Logic-Studio/BonjourDailyTips");
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
}