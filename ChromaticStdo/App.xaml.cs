﻿using ChromaticStdo.Views;

namespace ChromaticStdo;

public partial class App : Application
{
	public App(LoginPage loginPage)
	{
		InitializeComponent();

        var logueado = Preferences.Get("logueado", string.Empty);
        if (string.IsNullOrEmpty(logueado))
		{
			MainPage = loginPage;
        }
		else
		{
            MainPage = new AppShell();
        }

            
	}
}
