using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Interactivity;
using Avalonia.Layout;
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
        //app.Styles.Add(new Avalonia.Themes.Simple.SimpleTheme());
        app.Styles.Add(new Avalonia.Themes.Fluent.FluentTheme());
        app.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Light; // Default, Dark, Light

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

        AddButton(grid, "VStack", 0, 0, (s, e) => new VStackPanelWindow(),
            "Three controls stacked up\nvertically in a window.");

        AddButton(grid, "HStack", 0, 1, (s, e) => new HStackPanelWindow(),
            "Three controls lined up\nhorizontally in a window.");

        AddButton(grid, "Sliders &\nProgress", 0, 2, (s, e) => new SlidersProgressWindow(),
            "Some sliders linked to\nsome progress bars,\nwith numeric displays.");

        AddButton(grid, "Image", 0, 3, (s, e) => new ImageWindow(),
            "Display a bitmap image.");

        AddButton(grid, "Image\nProcessor", 1, 0, (s, e) => new ImageProcessWindow(),
            "Display a bitmap image\nand invert it.");

        AddButton(grid, "TextBox", 1, 1, (s, e) => new TextBoxWindow(),
            "Show an input text box\nand read its text.");

        AddButton(grid, "Dock &\nMenu", 1, 2, (s, e) => new MenuWindow(),
            "Five-part docking window\nand traditional menu.");

        AddButton(grid, "Canvas &\nLines", 1, 3, (s, e) => new CanvasWindow(),
            "Some line drawing.");

        AddButton(grid, "Canvas &\nUpdate", 2, 0, (s, e) => new CanvasUpdateWindow(),
            "Some lines that move.");

        AddButton(grid, "Canvas &\nShapes", 2, 1, (s, e) => new ShapesWindow(),
            "Some random shapes.");

        AddButton(grid, "Harmono\nGraph", 2, 2, (s, e) => new HarmonographWindow(),
            "Draw a damped Lissajous figure.");

        AddButton(grid, "Norton\nStarrs", 2, 3, (s, e) => new StarrWindow(),
            "A shape no mechanical system can draw.");

        win.Content = grid;
        win.Show();
        app.Run(win);
    }

    static void AddButton(Grid grid, string label, int row, int column, System.EventHandler<RoutedEventArgs> method, string tip)
    {
        Button button = new Button
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            Content = label,
            // Height = 120,
            // Width = 160,
            Margin = Thickness.Parse("10"),
            FontSize = 24,
            Background = Brushes.LightGray,
        };

        button.SetValue(ToolTip.TipProperty, tip);

        button.Styles.Add(
            new Style(x => x.OfType<Button>().Class(":pointerover").Template().Name("PART_ContentPresenter")) 
            {
                Setters = 
                {
                    new Setter(Button.BackgroundProperty, Brushes.White),
                    //new Setter(Button.ForegroundProperty, Brushes.Yellow),
                }
            });

        button.Styles.Add(
            new Style(x => x.OfType<Button>().Class(":pressed").Template().Name("PART_ContentPresenter"))
            {
                Setters = 
                {
                    new Setter(Button.BackgroundProperty, Brushes.Gray),
                    //new Setter(Button.ForegroundProperty, Brushes.Red),
                }
            });

        button.Click += method;

        // Viewbox viewbox = new Viewbox
        // {
        //     Child = button,
        //     Stretch = Stretch.Fill,
        //     Margin = Thickness.Parse("10"),
        // };

        // viewbox.SetValue(Grid.RowProperty, row);
        // viewbox.SetValue(Grid.ColumnProperty, column);
        
        // grid.Children.Add(viewbox);

        button.SetValue(Grid.RowProperty, row);
        button.SetValue(Grid.ColumnProperty, column);
        
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
