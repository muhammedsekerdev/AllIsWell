using AllIsWell.Users.Application.Abstractions;
using AllIsWell.Users.Domain;
using Microsoft.AspNetCore.Identity;

namespace AllIsWell.Users.Infrastructure.Security;

internal sealed class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

    public string Hash(string password)
    {
        return _hasher.HashPassword(null!, password);
    }

    public bool Verify(string password, string passwordHash)
    {
        PasswordVerificationResult result = _hasher.VerifyHashedPassword(null!, passwordHash, password);

        return result != PasswordVerificationResult.Failed;
    }
}
