using PasswordManager.Kernel;

namespace PasswordManager.Desktop.Infrastructure.Dtos;

public class LoginDto : Entity
{
    public string Title { get; set; } = "";
    public string? Icon { get; set; }
    public string? Username { get; set; }
    public virtual List<string> Passwords { get; set; } = [];
    public virtual List<string> Websites { get; set; } = [];
    public string? Notes { get; set; }
    public virtual List<TagToLoginDto> Tags { get; set; } = [];
}