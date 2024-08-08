using System.Diagnostics.Metrics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;

internal class HStackPanelWindow
{
    Label counter;
    int count;
    public HStackPanelWindow()
    {
        var win = new Window
        {
            Title = "StackPanelWindow v2.0",
            Height = 360,
            Width = 640,
        };

        var sp = new StackPanel();
        sp.Orientation = Orientation.Horizontal;

        sp.Children.Add(new Label{ Content = "Stack Label 1", FontSize = 24 });
        var button = new Button{ Content = "Hi!", FontSize = 24 };
        button.Click += Counter;
        sp.Children.Add(button);
        counter = new Label{ Content = "Pressed 0 times", FontSize = 24 };
        sp.Children.Add(counter);

        win.Content = sp;
        win.Show();
    }

    void Counter(object s, RoutedEventArgs e)
    {
        count = count + 1;
        counter.Content = $"Pressed {count} times";
    }
}