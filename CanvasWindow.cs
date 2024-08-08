using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

internal class CanvasWindow
{
    Canvas c;
    public CanvasWindow()
    {
        var win = new Window
        {
            Title = "CanvasWindow v2.0",
            Height = 360,
            Width = 640,
        };

        c = new Canvas()
        {
            Background = new SolidColorBrush(0xFF808080),
        };

        c.Children.Add(new Line {StartPoint = new Point(0, 0), EndPoint = new Point(200, 100), StrokeThickness=1.5, Stroke=Brushes.Black});

        var points = new Points
        {
            new Point(0, 10),
            new Point(200, 110),
            new Point(30, 10),
            new Point(100, 27),
        };

        var pl = new Polyline {Points = points, StrokeThickness=1.5, Stroke=Brushes.White};
        
        c.Children.Add(pl);

        win.Content = c;
        win.Show();
    }
}

