using PasswordManager.Kernel;

namespace PasswordManager.Desktop.Infrastructure.Dtos;

public class TagToLoginDto : Entity
{
    public Guid TagId { get; set; }
    public Guid LoginId { get; set; }
}