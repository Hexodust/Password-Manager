using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.ViewModels;

public partial class TodoItemViewModel : ViewModelBase
{
    private readonly Action<TodoItemViewModel> _removeTodoItemAction; 
    
    [ObservableProperty]
    private bool _isChecked;
    [ObservableProperty]
    private string? _content;

    public TodoItemViewModel()
    {
        _removeTodoItemAction = (item) => { };
    }
    
    public TodoItemViewModel(Action<TodoItemViewModel> removeTodoItemAction)
    {
        _removeTodoItemAction = removeTodoItemAction;
    }

    public TodoItemViewModel(TodoItem todoItem, Action<TodoItemViewModel> removeTodoItemAction)
    {
        _removeTodoItemAction = removeTodoItemAction;
        IsChecked = todoItem.IsChecked;
        Content = todoItem.Content;
    }

    public TodoItem GetTodoItem() => new()
    {
        IsChecked = IsChecked,
        Content = Content
    };

    [RelayCommand]
    private void Remove()
    {
        _removeTodoItemAction(this);
    }
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
