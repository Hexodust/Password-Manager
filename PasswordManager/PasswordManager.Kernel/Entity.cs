namespace PasswordManager.Kernel;

public class Entity<T>
{
    public T Id { get; set; } = default!;
}

public class Entity : Entity<Guid>;