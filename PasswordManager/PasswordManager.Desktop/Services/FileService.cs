using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.Services;

public class FileService
{
    private static string _jsonFilename =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PasswordManager",
            "todos.json");

    public static async Task SaveToFile(IEnumerable<TodoItem> items)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonFilename)!);
        
        await using var stream = File.Create(_jsonFilename);
        await JsonSerializer.SerializeAsync(stream, items);
    }
    
    public static async Task<IEnumerable<TodoItem>> LoadFromFile()
    {
        if (!File.Exists(_jsonFilename))
            return Array.Empty<TodoItem>();
        
        await using var stream = File.OpenRead(_jsonFilename);
        return await JsonSerializer.DeserializeAsync<IEnumerable<TodoItem>>(stream) ?? Array.Empty<TodoItem>();
    }
}