using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;

internal class TextBoxWindow
{
    Label lbl;
    public TextBoxWindow()
    {
        var win = new Window
        {
            Title = "InputTextWindow v2.0",
            Height = 360,
            Width = 640,
            Background = Brushes.Orange,
        };

        var sp = new StackPanel();

        var it = new TextBox()
        {
            FontSize = 24,
        };

        // Most of the time, you wouldn't use this. You'd respond to
        // some other event, like a button press, and query the TextBox.

        it.TextChanged += TextChanged;
        
        sp.Children.Add(it);

        lbl = new Label()
        {
            Background = Brushes.Aquamarine,
            FontSize = 24,
            Content = " ",
        };

        sp.Children.Add(lbl);

        win.Content = sp;
        win.Show();
    }

    void TextChanged(object s, RoutedEventArgs e)
    {
        lbl.Content = ((TextBox)s).Text;
    } 
}