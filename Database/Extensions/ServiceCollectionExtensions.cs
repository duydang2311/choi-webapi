using Choi.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection self)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new NullReferenceException("Missing CONNECTION_STRING environment variable");
        return self
            .AddPooledDbContextFactory<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
    }
}
