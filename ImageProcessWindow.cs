using System.Diagnostics;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;

internal class ImageProcessWindow
{
    public ImageProcessWindow()
    {
        var win = new Window
        {
            Title = "ImageProcessWindow v2.0",
            Height = 640,
            Width = 640,
            Background = Brushes.Magenta,
        };

        var img = new Image()
        {
            Source = new Bitmap("OldFriend.png"),
            Stretch = Avalonia.Media.Stretch.None,
        };

        img.PointerPressed += Invert;
        img.PointerReleased += Invert;

        win.Content = img;
        win.Show();
    }

    // To compile unsafe code, add this to a PropertyGroup in the .csproj:
    //
    //     <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    unsafe void Invert(object s, RoutedEventArgs e)
    {
        Image img = (Image)s;

        using var memoryStream = new MemoryStream();
        
        ((Bitmap)img.Source).Save(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);
        var writeableBitmap = WriteableBitmap.Decode(memoryStream);
        using var lockedBitmap = writeableBitmap.Lock();

        byte* bmpPtr = (byte*)lockedBitmap.Address;
        int width = writeableBitmap.PixelSize.Width;
        int height = writeableBitmap.PixelSize.Height;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                bmpPtr[0] = (byte)~bmpPtr[0]; // red
                bmpPtr[1] = (byte)~bmpPtr[1]; // grn
                bmpPtr[2] = (byte)~bmpPtr[2]; // blu (screw you, Paul)
                bmpPtr += 4;                  // alf
            }
        }

        img.Source = writeableBitmap;
    }
}