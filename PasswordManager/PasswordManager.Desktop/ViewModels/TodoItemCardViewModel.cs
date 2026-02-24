using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.ViewModels;

public partial class TodoItemCardViewModel : ViewModelBase
{
    // Username; Pass; Website/App; Title
    [ObservableProperty]
    private string? _username;
    [ObservableProperty]
    private string _password;
    [ObservableProperty]
    private string? _application;
    [ObservableProperty]
    private string _title;

    public Action<TodoItemCardViewModel> RemoveItem { get; init; }
    
    public TodoItemCardViewModel()
    {
        
    }

    public TodoItemCardViewModel(TodoItem todoItem)
    {
        Username = todoItem.Username;
        Title = todoItem.Title;

    }

    public TodoItem GetTodoItem() => new()
    {
        Username = Username,
        Title = Title
    };

    [RelayCommand]
    private void Remove()
    {
        RemoveItem(this);
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
