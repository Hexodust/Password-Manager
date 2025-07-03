using PasswordManager.Desktop.Infrastructure.Dtos;
using PasswordManager.Kernel;

namespace PasswordManager.Desktop.Models;

public class Tag : Entity
{
    public string Name { get; set; } = "";
    public virtual List<TagToLoginDto> LoginIds { get; set; } = [];
}