using PasswordManager.Kernel;

namespace PasswordManager.Desktop.Infrastructure.Dtos;

public class PasswordDto : Entity
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
}