using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Desktop.Models;
using PasswordManager.Kernel;

namespace PasswordManager.Desktop.ViewModels;

public partial class LoginCardViewModel : Audit
{
    [ObservableProperty] private string _title;
    [ObservableProperty] private string? _subTitle;
    [ObservableProperty] private string? _icon;

    public LoginCardViewModel()
    {
        
    }

    public LoginCardViewModel(Login login)
    {
        _title = login.Title;
        _subTitle = login.Username;
        _icon = login.Icon;
    }
}

public partial class LoginDetailViewModel : Audit
{
    [ObservableProperty] private string _title = "Login";
    [ObservableProperty] private string _icon = "N/A";
    [ObservableProperty] private string _username = "";
    [ObservableProperty] private List<Password> _passwords = [new Password("password", "")];
    [ObservableProperty] private List<string> _websites = [""];
    [ObservableProperty] private string _notes = "";
    [ObservableProperty] private List<string> _tags = [""];

    public LoginDetailViewModel()
    {
    }

    public LoginDetailViewModel(Login login)
    {
        _title = login.Title;
        _icon = login.Icon ?? "default";
        _username = login.Username ?? "N/A";
        _passwords = login.Passwords;
        _websites = login.Websites;
        if (_websites.Count == 0)
            _websites = [""];
        _notes = login.Notes ?? "";
        _tags = login.Tags;
    }
}

