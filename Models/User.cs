using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Choi.WebApi.Models;

public sealed class User
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(64);
        builder.Property(e => e.Email).HasMaxLength(254);
        builder.Property(e => e.Password).HasMaxLength(61);
    }
}
