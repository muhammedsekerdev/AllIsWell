using AllIsWell.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace AllIsWell.Users.Infrastructure.Database;

public sealed class UsersDbContext : DbContext
{
    public const string Schema = "users";

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
    }
}
