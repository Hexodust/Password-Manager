using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Desktop.DiRegistration;
using PasswordManager.Desktop.Services;
using PasswordManager.Desktop.ViewModels;
using PasswordManager.Desktop.Views;

namespace PasswordManager.Desktop;

public partial class App : Application
{
    private bool _canClose = false;
    private MainWindowViewModel _mainWindowViewModel;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        // Remove Avalonia validations
        // We use validations from CommunityToolkit
        BindingPlugins.DataValidators.RemoveAt(0);
        
        // Register services
        var services = new ServiceCollection();
        services.RegisterCommonServices();
        var provider = services.BuildServiceProvider();
        _mainWindowViewModel = provider.GetRequiredService<MainWindowViewModel>();
        
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