using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.Services;

public static class TodoListFileService
{
    private static readonly string JsonFilename = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "PasswordManager", "TodoList.json");

    public static async Task SaveToFIleAsync(IEnumerable<TodoItem> todoItems)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(JsonFilename)!);

        await using var stream = File.Create(JsonFilename);
        
        await JsonSerializer.SerializeAsync(stream, todoItems);
    }

    public static async Task<IEnumerable<TodoItem>> LoadFromFileAsync()
    {
        try
        {
            await using var stream = File.OpenRead(JsonFilename);
            return await JsonSerializer.DeserializeAsync<IEnumerable<TodoItem>>(stream) ?? [];
        }
        catch (FileNotFoundException e)
        {
            return [];
        }
        catch (DirectoryNotFoundException e)
        {
            return [];
        }
    }
}