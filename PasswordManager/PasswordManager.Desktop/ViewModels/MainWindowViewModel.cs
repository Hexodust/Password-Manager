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
    [ObservableProperty]
    private TodoItemDetailViewModel? _newItemTodoItem;
    
    public ObservableCollection<TodoItemCardViewModel> TodoItems { get; } = new();
    public bool CanAddItem => !string.IsNullOrWhiteSpace(NewItemPassword) && !string.IsNullOrWhiteSpace(NewItemTitle);
    
    // Todo: Add constructor and dummy data for NewItemTodoItem
    
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        TodoItems.Add(new TodoItemCardViewModel()
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

    private void RemoveItem(TodoItemCardViewModel itemCard)
    {
        TodoItems.Remove(itemCard);
    }

}