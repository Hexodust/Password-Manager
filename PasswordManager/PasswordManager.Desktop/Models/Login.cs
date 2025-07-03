using System.Collections.Generic;
using PasswordManager.Kernel;

namespace PasswordManager.Desktop.Models;

public record Login(
    string Title,
    string? Icon,
    string? Username,
    List<Password> Passwords,
    List<string> Websites,
    string? Notes,
    List<string> Tags
    );