﻿namespace BonjourDailyTips;
using BonjourDailyTips.Helpers;
using BonjourDailyTips.ViewModels;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
