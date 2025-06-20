using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PasswordManager.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (double.TryParse(Celsius.Text, out var celsius))
        {
            var fahrenheit = celsius * (9d / 5d) + 32;
            Fahrenheit.Text = fahrenheit.ToString("0.0");
        }
        else
        {
            Celsius.Text = "0";
            Fahrenheit.Text = "0";
        }
    }

    private void Celsius_OnChange(object? sender, TextChangedEventArgs e)
    {
        if (double.TryParse(Celsius.Text, out var celsius))
        {
            var fahrenheit = celsius * (9d / 5d) + 32;
            Fahrenheit.Text = fahrenheit.ToString("0.0");
        }
        else
        {
            Fahrenheit.Text = "0";
        }
    }
}