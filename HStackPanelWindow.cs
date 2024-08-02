using Avalonia.Controls;
using Avalonia.Layout;

internal class HStackPanelWindow
{
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
        sp.Children.Add(new Button{ Content = "Hi!", FontSize = 24 });
        sp.Children.Add(new Label{ Content = "Stack Label 2", FontSize = 24 });

        win.Content = sp;
        win.Show();
    }
}