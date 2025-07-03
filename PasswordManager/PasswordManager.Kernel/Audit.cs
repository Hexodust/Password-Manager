using CommunityToolkit.Mvvm.ComponentModel;

namespace PasswordManager.Kernel;

public class Audit : ObservableObject, IAudit
{
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; } = "";
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; } = "";
}