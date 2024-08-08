using System;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

internal class MenuWindow
{
    Rectangle rCenter;

    Commander c = new Commander();
    public MenuWindow()
    {
        var win = new Window
        {
            Title = "MenuWindow v2.0",
            Height = 360,
            Width = 640,
        };

        // Note that we MUST add at least two children to the DockPanel.
        // That's because the last child is always put in the center
        // unless DockPanel.LastChildFill is set to false.

        var dp = new DockPanel();

        var menu = new Menu
        {
            Background = Brushes.LightGray,
            Foreground = Brushes.Black,
            FontSize = 16,
            Height = 24,

            ItemsSource = new[]
            {
                new MenuItem
                {
                    Header = "File",

                    ItemsSource = new[]
                    {
                        new MenuItem
                        {
                            Header = "Open",

                            ItemsSource = new[]
                            {
                                new MenuItem
                                {
                                    Header = "This",
                                    Command = c,
                                    CommandParameter = "Hello Parameter World!",
                                },

                                new MenuItem
                                {
                                    Header = "That",
                                },

                                new MenuItem
                                {
                                    Header = "The Other",
                                },
                            },
                        },

                        new MenuItem
                        {
                            Header = "Save",
                        },

                        new MenuItem
                        {
                            Header = "Close",
                        },
                    },
                },

                new MenuItem
                {
                    Header = "_Edit",
                },

                new MenuItem
                {
                    Header = "_Help",
                },
            },
        };

        menu.SetValue(DockPanel.DockProperty, Dock.Top);

        dp.Children.Add(menu);

        var rLeft = new Rectangle
        {
            Fill = Brushes.Blue,
            Width = 100,
        };

        rLeft.SetValue(DockPanel.DockProperty, Dock.Left);

        dp.Children.Add(rLeft);

        var rBottom = new Rectangle
        {
            Fill = Brushes.Green,
            Height = 100,
        };

        rBottom.SetValue(DockPanel.DockProperty, Dock.Bottom);

        dp.Children.Add(rBottom);

        var rRight = new Rectangle
        {
            Fill = Brushes.Orange,
            Width = 100,
        };

        rRight.SetValue(DockPanel.DockProperty, Dock.Right);

        dp.Children.Add(rRight);

        rCenter = new Rectangle
        {
            Fill = Brushes.Gray,
        };

        dp.Children.Add(rCenter);

        win.Content = dp;
        win.Show();
    }
}

internal class Commander : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        Debug.WriteLine("CanExecute called");
        return true; // false here to disable this menu item
    }

    public void Execute(object parameter)
    {
        Debug.WriteLine($"Execute called with {(string)parameter}");
    }
}