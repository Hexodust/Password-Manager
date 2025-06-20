using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.ViewModels;

public partial class TodoItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isChecked;
    [ObservableProperty]
    private string? _content;
    
    public TodoItemViewModel()
    {
        
    }

    public TodoItemViewModel(TodoItem todoItem)
    {
        IsChecked = todoItem.IsChecked;
        Content = todoItem.Content;
    }

    public TodoItem GetTodoItem() => new()
    {
        IsChecked = IsChecked,
        Content = Content
    };
}

// interface IPerson
// {
//     // This is da function declaration
//     string SayHello();
// }
//
// class Person : IPerson
// {
//     // This is a function definition
//     public string SayHello()
//     {
//         return "Hello";
//     }
// }
