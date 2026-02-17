using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemUsername;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string _newItemPassword;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemApplication;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string _newItemTitle;
    
    public ObservableCollection<TodoItemViewModel> TodoItems { get; } = new();
    public bool CanAddItem => !string.IsNullOrWhiteSpace(NewItemPassword) && !string.IsNullOrWhiteSpace(NewItemTitle);
    
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        TodoItems.Add(new TodoItemViewModel()
        {
            Username = NewItemUsername,
            Password = NewItemPassword,
            Application = NewItemApplication,
            Title = NewItemTitle,
            RemoveItem = RemoveItem
        });
        NewItemUsername = null;
        NewItemPassword = null;
        NewItemApplication = null;
        NewItemApplication = null;
    }

    private void RemoveItem(TodoItemViewModel item)
    {
        TodoItems.Remove(item);
    }

}