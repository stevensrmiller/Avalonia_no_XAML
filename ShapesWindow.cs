using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

internal class ShapesWindow
{
    Random rand = new Random();
    Canvas c;
    public ShapesWindow()
    {
        var win = new Window
        {
            Title = "ShapesWindow v2.0",
            Height = 360,
            Width = 640,
        };

        c = new Canvas()
        {
            Background = new SolidColorBrush(0xFF808080),
        };

        win.Content = c;

        win.Show();

        DrawShapes(c);
        c.PointerPressed += (s, e) => DrawShapes(c);
    }

    void DrawShapes(Canvas c)
    {
        c.Children.Clear();

        float cw = (float)c.Bounds.Width;
        float ch = (float)c.Bounds.Height;

        for (int i = 0; i < 100; ++i)
        {
            var b = new SolidColorBrush();

            b.Color = new Color(0XFF, 
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()));

            float x = cw * (float)rand.NextDouble();
            float y = ch * (float)rand.NextDouble();

            float w = (cw - x) * (float)rand.NextDouble();
            float h = (ch - y) * (float)rand.NextDouble();

            Rectangle r = new Rectangle{Fill = b, Width = w, Height = h};
            r.SetValue(Canvas.LeftProperty, x);
            r.SetValue(Canvas.TopProperty, y);
            c.Children.Add(r);

            b = new SolidColorBrush();

            b.Color = new Color(0XFF, 
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()));

            x = cw * (float)rand.NextDouble();
            y = ch * (float)rand.NextDouble();

            w = (cw - x) * (float)rand.NextDouble();
            h = (ch - y) * (float)rand.NextDouble();

            Ellipse e = new Ellipse{Fill = b, Width = w, Height = h};
            e.SetValue(Canvas.LeftProperty, x);
            e.SetValue(Canvas.TopProperty, y);
            c.Children.Add(e);
        }
    }
}

