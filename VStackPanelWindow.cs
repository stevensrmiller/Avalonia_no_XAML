using System;
using System.Windows.Input;
using Avalonia.Controls;

internal class VStackPanelWindow
{
    public VStackPanelWindow()
    {
        var win = new Window
        {
            Title = "StackPanelWindow v2.0",
            Height = 360,
            Width = 640,
        };

        var sp = new StackPanel();

        sp.Children.Add(new Label{ Content = "Stack Label 1", FontSize = 24 });
        Button button = new Button{ Content = "Hi!", FontSize = 24 };
        sp.Children.Add(button);
        Label count = new Label{ Content = "Count = 0", FontSize = 24 };
        sp.Children.Add(count);

        button.Command = new Command(count);

        win.Content = sp;
        win.Show();
    }
}

class Command : ICommand
{
    Label count;
    int n;
    public event EventHandler CanExecuteChanged;

    public Command(Label count)
    {
        this.count = count;
    }

    public bool CanExecute(object parameter)
    {
        return n < 5;
    }

    public void Execute(object parameter)
    {
        if (n < 4)
        {
            n = n + 1;
            count.Content = $"Count = {n}";
        }
        else
        {
            count.Content = $"{n} That will do.";
        }
    }
}