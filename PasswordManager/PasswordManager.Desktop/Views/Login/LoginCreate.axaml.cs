using Avalonia.Controls;
using PasswordManager.Desktop.ViewModels;

namespace PasswordManager.Desktop.Views.Login;

public partial class LoginCreate : UserControl
{
    public LoginCreate()
    {
        InitializeComponent();
        DataContext = new LoginDetailViewModel();
    }

    public void OnSave()
    {
        
    }
}