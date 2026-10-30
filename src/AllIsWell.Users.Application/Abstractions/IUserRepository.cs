using AllIsWell.Users.Domain;

namespace AllIsWell.Users.Application.Abstractions;

public interface IUserRepository
{
    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);

    void Add(User user);
}
