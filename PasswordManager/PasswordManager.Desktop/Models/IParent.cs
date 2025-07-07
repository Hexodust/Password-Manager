using CommunityToolkit.Mvvm.Input;

namespace PasswordManager.Desktop.Models;

public interface IParent
{
    IRelayCommand RemoveCommand { get; }
}