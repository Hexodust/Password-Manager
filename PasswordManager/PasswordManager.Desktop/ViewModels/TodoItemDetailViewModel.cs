using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.ViewModels;

public partial class TodoItemDetailViewModel : ViewModelBase
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

    public Action<TodoItemDetailViewModel> RemoveItem { get; init; }
    
    public TodoItemDetailViewModel()
    {
        
    }

    public TodoItemDetailViewModel(TodoItem todoItem)
    {
        Username = todoItem.Username;
        Password = todoItem.Password;
        Application = todoItem.Application;
        Title = todoItem.Title;

    }

    public TodoItem GetTodoItem() => new()
    {
        Username = Username,
        Password = Password,
        Application = Application,
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
