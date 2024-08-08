using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;

internal class ImageWindow
{
    public ImageWindow()
    {
        var win = new Window
        {
            Title = "ImageWindow v2.0",
            Height = 640,
            Width = 640,
            Background = Brushes.Magenta,
        };

        var img = new Image()
        {
            Source = new Bitmap("OldFriend.png"),
            Stretch = Avalonia.Media.Stretch.None,
        };

        win.Content = img;
        win.Show();
    }
}