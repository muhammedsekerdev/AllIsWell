using AllIsWell.Shared.Kernel;

namespace AllIsWell.Users.Domain;

public sealed class User : IEntity
{
    private User()
    {
    }

    public Guid Id { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public UserType Type { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public static User Create(string email, string passwordHash, UserType type, DateTime createdAtUtc)
    {
        return new User
        {
            Id = Guid.CreateVersion7(),
            Email = email.Trim().ToLowerInvariant(),
            PasswordHash = passwordHash,
            Type = type,
            CreatedAtUtc = createdAtUtc
        };
    }
}
