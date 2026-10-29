using AllIsWell.Users.Domain;

namespace AllIsWell.Users.Infrastructure.Database;

internal sealed class UserTypeLookup
{
    public UserType Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
