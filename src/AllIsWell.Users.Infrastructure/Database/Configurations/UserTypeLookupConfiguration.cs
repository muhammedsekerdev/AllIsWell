using AllIsWell.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllIsWell.Users.Infrastructure.Database.Configurations;

internal sealed class UserTypeLookupConfiguration : IEntityTypeConfiguration<UserTypeLookup>
{
    public void Configure(EntityTypeBuilder<UserTypeLookup> builder)
    {
        builder.ToTable("user_types");

        builder.HasKey(userType => userType.Id);

        builder.Property(userType => userType.Id)
            .ValueGeneratedNever();

        builder.Property(userType => userType.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasData(
            Enum.GetValues<UserType>()
                .Select(userType => new UserTypeLookup
                {
                    Id = userType,
                    Name = userType.ToString()
                }));
    }
}
