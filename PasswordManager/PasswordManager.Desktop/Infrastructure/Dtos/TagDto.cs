using PasswordManager.Kernel;

namespace PasswordManager.Desktop.Infrastructure.Dtos;

public class Tag : Entity
{
    public string Name { get; set; } = "";
    public virtual List<TagToLoginDto> LoginIds { get; set; } = [];
}