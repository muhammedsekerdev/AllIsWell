using AllIsWell.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllIsWell.Users.Infrastructure.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.PasswordHash)
            .IsRequired();

        builder.Property(user => user.Type)
            .HasColumnName("user_type_id")
            .IsRequired();

        builder.HasOne<UserTypeLookup>()
            .WithMany()
            .HasForeignKey(user => user.Type)
            .HasConstraintName("fk_users_user_types_user_type_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(user => user.CreatedAtUtc)
            .IsRequired();
    }
}
