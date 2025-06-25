using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData;
using PasswordManager.Desktop.Services;
using PasswordManager.Desktop.ViewModels;
using PasswordManager.Desktop.Views;

namespace PasswordManager.Desktop;

public partial class App : Application
{
    private bool _canClose = false;
    private readonly MainWindowViewModel _mainWindowViewModel = new();
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

            desktop.ShutdownRequested += OnShutdownRequested;
        }

        await InitMainViewModelAsync();
        base.OnFrameworkInitializationCompleted();
    }

    private async Task InitMainViewModelAsync()
    {
        var items = (await TodoListFileService.LoadFromFileAsync())
            .Select(item => new TodoItemViewModel(item, _mainWindowViewModel.RemoveItem))
            .ToList();
        
        if (items.Count == 0)
            return;
        
        _mainWindowViewModel.TodoItems.AddRange(items);
    }

    private async void OnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        e.Cancel = !_canClose;

        if (_canClose) return;
        
        var items = _mainWindowViewModel.TodoItems.Select(item => item.GetTodoItem());
        await TodoListFileService.SaveToFIleAsync(items);
            
        _canClose = true;
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}