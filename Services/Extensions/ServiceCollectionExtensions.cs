using Choi.WebApi.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddChoiServices(this IServiceCollection self)
    {
        return self
            .AddSingleton<IApiResponder>(new ApiResponder("v1"))
        ;
    }
}
