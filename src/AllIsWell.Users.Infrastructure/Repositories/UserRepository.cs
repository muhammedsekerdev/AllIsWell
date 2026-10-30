using AllIsWell.Users.Application.Abstractions;
using AllIsWell.Users.Domain;
using AllIsWell.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AllIsWell.Users.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context)
    {
        _context = context;
    }

    public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
    {
        return _context.Users.AnyAsync(user => user.Email == email, cancellationToken);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }
}
