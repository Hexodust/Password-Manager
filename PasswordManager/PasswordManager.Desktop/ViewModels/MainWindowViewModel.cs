using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
        TodoItems.Add(new TodoItemViewModel(){Content = NewItemContent});
        NewItemContent = null;
    }

    [RelayCommand]
    private void RemoveItem(TodoItemViewModel item)
    {
        TodoItems.Remove(item);
    }

}