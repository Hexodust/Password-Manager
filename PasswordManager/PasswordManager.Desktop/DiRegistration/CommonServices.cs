using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Desktop.Services;
using PasswordManager.Desktop.ViewModels;

namespace PasswordManager.Desktop.DiRegistration;

public static class CommonServices
{
    public static void RegisterCommonServices(this IServiceCollection services)
    {
        services.AddTransient<PasswordService>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<LoginCardViewModel>();
        services.AddTransient<LoginDetailViewModel>();
    }
}