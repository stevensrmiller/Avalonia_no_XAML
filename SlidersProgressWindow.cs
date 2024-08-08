using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Fonts;
using Avalonia.Styling;

internal class SlidersProgressWindow
{
    ProgressBar progBarH;
    ProgressBar progBarV;
    Label labelH;
    Label labelV;
    public SlidersProgressWindow()
    {
        var win = new Window
        {
            Title = "SlidersProgressWindow v3.0",
            Height = 360,
            Width = 640,
        };

        Grid grid = new Grid
        {
            ShowGridLines = true,
            Background = Brushes.Yellow,
            RowDefinitions = RowDefinitions.Parse("50*, 25*, 25*"),
            ColumnDefinitions = ColumnDefinitions.Parse("50*, 25*, 25*"),
        };

        Slider sliderH = new Slider
        {
            Minimum = -10,
            Maximum = 50,
            Value = -10,
            Margin = Thickness.Parse("10"),
            VerticalAlignment = VerticalAlignment.Center,
        };

        sliderH.SetValue(Grid.RowProperty, 2);
        sliderH.SetValue(Grid.ColumnProperty, 0);
        sliderH.PointerMoved += SliderHMoved;
        
        // sliderH.Styles.Add(
        //                 new Style(x => x.OfType<Slider>().Class(":horizontal"))
        //                 {
        //                         Setters =
        //                         {
        //                                 new Setter(Slider.HeightProperty, 150.0),
        //                         }
        //                 });

        grid.Children.Add(sliderH);

        Slider sliderV = new Slider
        {
            Minimum = 10,
            Maximum = 150,
            Value = 80,
            Margin = Thickness.Parse("10"),
            HorizontalAlignment = HorizontalAlignment.Center,
            Orientation = Orientation.Vertical,
        };
        
        grid.Children.Add(sliderV);

        sliderV.SetValue(Grid.RowProperty, 0);
        sliderV.SetValue(Grid.RowSpanProperty, 3);
        sliderV.SetValue(Grid.ColumnProperty, 2);
        sliderV.PointerMoved += SliderVMoved;
 
        progBarH = new ProgressBar
        {
            Minimum = -10,
            Maximum = 50,
            Value = -10,
            Height = 20,
            Margin = Thickness.Parse("10"),
            VerticalAlignment = VerticalAlignment.Center,
        };

        progBarH.SetValue(Grid.RowProperty, 1);
        progBarH.SetValue(Grid.ColumnProperty, 0);
        //progBarH.SetValue(Grid.ColumnSpanProperty, 2);
        
        grid.Children.Add(progBarH);

        progBarV = new ProgressBar
        {
            Minimum = 10,
            Maximum = 150,
            Value = 80,
            Width = 20,
            Margin = Thickness.Parse("10"),
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Stretch,
            Orientation = Orientation.Vertical,
        };

        grid.Children.Add(progBarV);

        progBarV.SetValue(Grid.RowProperty, 0);
        progBarV.SetValue(Grid.RowSpanProperty, 3);
        progBarV.SetValue(Grid.ColumnProperty, 1);
        
        labelH = new Label
        {
            VerticalAlignment = VerticalAlignment.Bottom,
            FontSize = 24,
            FontFamily = "Liberation Mono",
            FontWeight = FontWeight.Bold,
            Width = 200,
        };

        labelH.SetValue(Grid.RowProperty, 0);
        labelH.SetValue(Grid.ColumnProperty, 0);

        grid.Children.Add(labelH);

        labelV = new Label
        {
            VerticalAlignment = VerticalAlignment.Top,
            FontSize = 24,
            FontFamily = "Stencil",
            FontWeight = FontWeight.Bold,
            Width = 200,
        };

        labelV.SetValue(Grid.RowProperty, 0);
        labelV.SetValue(Grid.ColumnProperty, 0);

        grid.Children.Add(labelV);

        win.Content = grid;
        win.Show();
    }

    void SliderHMoved(object s, RoutedEventArgs e)
    {
        Slider slider = s as Slider;
        progBarH.Value = slider.Value;
        labelH.Content = $"H = {slider.Value,8:0.00}";
    }

    void SliderVMoved(object s, RoutedEventArgs e)
    {
        Slider slider = s as Slider;
        progBarV.Value = slider.Value;
        labelV.Content = $"V = {slider.Value,8:0.00}";
    }
}