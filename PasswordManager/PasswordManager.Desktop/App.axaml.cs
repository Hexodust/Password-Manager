using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DynamicData;
using PasswordManager.Desktop.Services;
using PasswordManager.Desktop.ViewModels;
using PasswordManager.Desktop.Views;

namespace PasswordManager.Desktop;

public partial class App : Application
{
    private static readonly MainWindowViewModel _mainWindowViewModel = new();
    private bool _canShutdown = false;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _mainWindowViewModel,
            };
            desktop.ShutdownRequested += OnShoutdown;
        }

        base.OnFrameworkInitializationCompleted();

        await InitTodos();
    }

    private async Task InitTodos()
    {
        var items = (await FileService.LoadFromFile())
            .Select(item => new TodoItemViewModel(item))
            .ToList();
        _mainWindowViewModel.TodoItems.AddRange(items);
    }

    private async void OnShoutdown(object? sender, ShutdownRequestedEventArgs e)
    {
        e.Cancel = !_canShutdown;
        
        if (_canShutdown) return;
        
        var items = _mainWindowViewModel.TodoItems.Select(item => item.GetTodoItem()).ToList();
        await FileService.SaveToFile(items);
        
        _canShutdown = true;
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}