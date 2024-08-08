using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;

internal class CanvasUpdateWindow
{
    Point start = new Point(320, 90);
    Point end = new Point(320, 270);
    Line blackLine = new Line {StrokeThickness=1.5, Stroke=Brushes.Black};
    Polyline polyLine = new Polyline {StrokeThickness=1.5, Stroke=Brushes.White};
    Point[] points;
    Canvas c;
    public CanvasUpdateWindow()
    {
        var win = new Window
        {
            Title = "CanvasUpdateWindow v2.0",
            Height = 360,
            Width = 640,
        };

        c = new Canvas()
        {
            Background = new SolidColorBrush(0xFF808080),
        };

        blackLine.StartPoint = start;
        blackLine.EndPoint = end;

        c.Children.Add(blackLine);

        c.PointerPressed += PointerPressed;

        points = new Point[40];

        polyLine.Points = SetPoints(points);
        
        c.Children.Add(polyLine);

        win.Content = c;
        win.Show();
    }

    void PointerPressed(object s, RoutedEventArgs e)
    {
        blackLine.StartPoint = blackLine.StartPoint.WithX(blackLine.StartPoint.X + 10);
        blackLine.EndPoint = blackLine.EndPoint.WithX(blackLine.EndPoint.X - 10);
        polyLine.Points = SetPoints(points); // PolyLine only sees changes if the Points object changes.
    }

    float nextY = 53;
    Point[] SetPoints(Point[] points)
    {
        int numPoints = points.Length;

        Point[] newPoints = new Point[numPoints];

        for (int i = 0; i < numPoints; ++i)
        {
            float x = 160 * (1 + 2 * i / (numPoints - 1f));
            float y = 280 + nextY;

            newPoints[i] = new Point(x, y);

            nextY = (1.73f * nextY * nextY + nextY + 137) % 70;
        }

        return newPoints;
    }
}

