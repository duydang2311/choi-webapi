using Choi.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Choi.WebApi.Database;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext() : base() { }
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new NullReferenceException("Missing CONNECTION_STRING environment variable");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
