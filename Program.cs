using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;

class MainClass
{
    public static void Main(string[] args) {
        AppBuilder
            .Configure<Application>()
            .UsePlatformDetect()
            .Start(AppMain, args);
    }

    public static void AppMain(Application app, string[] args)
    {
        app.Styles.Add(new Avalonia.Themes.Simple.SimpleTheme());
        app.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Default; // Default, Dark, Light

        var win = new Window
        {
            Title = "Avalonia C# Examples",
            Width = 800,
            Height = 600,
            Background = Brushes.Orange,
        };

        Grid grid = new Grid
        {
            ShowGridLines = true,
            Background = Brushes.SeaGreen,
            RowDefinitions = RowDefinitions.Parse("*, *, *, *"),
            ColumnDefinitions = ColumnDefinitions.Parse("*, *, *, *")
        };

        AddButton(grid, "VStack", 0, 0, (s, e) => new VStackPanelWindow());
        AddButton(grid, "HStack", 0, 1, (s, e) => new HStackPanelWindow());
        AddButton(grid, "Sliders &\nProgress", 0, 2, (s, e) => new SlidersProgressWindow());

        win.Content = grid;
        win.Show();
        app.Run(win);
    }

    static void AddButton(Grid grid, string label, int row, int column, System.EventHandler<RoutedEventArgs> method)
    {
        Button button = new Button
        {
            Content = label,
            FontSize = 24,
            Margin = Thickness.Parse("10"),
        };

        button.SetValue(Grid.RowProperty, row);
        button.SetValue(Grid.ColumnProperty, column);

        button.Click += method;
        grid.Children.Add(button);
    }
}

#if false
        clearButton = new Button {Content = "Clear", FontSize = 48};
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

        var btnStackPanel = new Button
        {
            Content = "Stack",
            Margin = Thickness.Parse("16"),
            FontSize = 24,
        };
        
        btnStackPanel.SetValue(Grid.RowProperty, 2);
        btnStackPanel.ClickMode = ClickMode.Press;
        btnStackPanel.Click += (s, e) => new StackPanelWindow();

        grid.Children.Add(btnStackPanel);

        app.Run(win);
    }

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
