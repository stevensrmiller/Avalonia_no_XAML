﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

class MainClass {
    public static void Main(string[] args) {
        AppBuilder
            .Configure<Application>()
            .UsePlatformDetect()
            .Start(AppMain, args);
    }

    public static void AppMain(Application app, string[] args) {
        // Application needs a theme to render window content
        app.Styles.Add(new Avalonia.Themes.Simple.SimpleTheme());
        app.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Default; // Default, Dark, Light

        // Create window
        var win = new Window();
        win.Title = "Avalonia no XAML";
        win.Width = 800;
        win.Height = 600;

        var text = new Button(); //new Label();
		text.Click += ButtonClicked;
        win.Content = text;

        text.Content = "Hello from C#!";
        text.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        text.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
        text.FontSize = 72;

        win.Show();
        app.Run(win);
    }
	
	public static void ButtonClicked(object sender, RoutedEventArgs args)
	{
		Button b = sender as Button;
		b.Content = "Hey!!!";
	}
}
