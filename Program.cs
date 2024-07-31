using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Layout;

class MainClass {

    static Canvas canvas;
    static Label right;
    static int x = 0;
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
        var win = new Window
        {
            Title = "Avalonia no XAML here's hopin' 3",
            Width = 800,
            Height = 600,
            Background = Brushes.Orange,
        };

        Grid grid = new Grid();
        grid.ShowGridLines = true;
        grid.Background = Brushes.SeaGreen;
        grid.RowDefinitions = RowDefinitions.Parse("20*, 80*");
        grid.ColumnDefinitions = ColumnDefinitions.Parse("25*, 25*, 50*");

        Button clearButton = new Button {Content = "Clear", FontSize = 48};
        clearButton.Click += ClearClicked;
        Grid.SetColumn(clearButton, 0);
        grid.Children.Add(clearButton);
        
        right = new Label {Content = "Right Child", FontSize = 24};
        Grid.SetColumn(right, 2);
        grid.Children.Add(right);

        Button button = new Button {Content = "Press me!", FontSize = 48};
        button.Margin = Thickness.Parse("10");
        button.Height = 100;
        button.Click += ButtonClicked;
        Grid.SetRow(button, 1);
        Grid.SetColumnSpan(button, 2);
        grid.Children.Add(button);

        canvas = new Canvas {Background = Brushes.Cyan};
        Grid.SetRow(canvas, 1);
        Grid.SetColumn(canvas, 2);
        grid.Children.Add(canvas);

        Slider slider = new Slider();
        slider.VerticalAlignment = VerticalAlignment.Center;
        slider.PointerMoved += PointerMoved;
        Grid.SetColumn(slider, 1);
        grid.Children.Add(slider);

        win.Content = grid;
        win.Show();
        app.Run(win);
    }

#if false	
        win.Content = new Line {StartPoint=new Point(219.5,185.5), EndPoint=new Point(217.5,115.5), StrokeThickness=1, Stroke=new SolidColorBrush(0xFF000000)};

        // or

        var text = new Button(); //new Label();
		text.Click += ButtonClicked;
        win.Content = text;

        text.Content = "Hello from C#!";
        text.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        text.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
        text.FontSize = 72;
#endif

	public static void ButtonClicked(object sender, RoutedEventArgs args)
	{
		canvas.Children.Add(new Line {StartPoint=new Point(x, 200), EndPoint=new Point(100, 100), StrokeThickness=1, Stroke=new SolidColorBrush(0xFF000000)});
        x = x + 10;
	}

    public static void ClearClicked(object sender, RoutedEventArgs args)
    {
        canvas.Children.Clear();
        x = 0;
    }

    public static void PointerMoved(object sender, RoutedEventArgs args)
    {
        Slider slider = sender as Slider;

        right.Content = $"{slider.Value}";
    }
}
