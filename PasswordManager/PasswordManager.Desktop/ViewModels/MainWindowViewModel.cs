using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemContent;
    
    public ObservableCollection<TodoItemViewModel> TodoItems { get; } = new();
    public bool CanAddItem => !string.IsNullOrWhiteSpace(NewItemContent);
    
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        TodoItems.Add(new TodoItemViewModel(){ Content = NewItemContent, RemoveItem = RemoveItem });
        NewItemContent = null;
    }

    private void RemoveItem(TodoItemViewModel item)
    {
        TodoItems.Remove(item);
    }

}