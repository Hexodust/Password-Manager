using Microsoft.EntityFrameworkCore;
using PasswordManager.Desktop.Models;

namespace PasswordManager.Desktop.Infrastructure;

public class PasswordContext : DbContext
{
    public DbSet<Login> Passwords { get; set; }
}