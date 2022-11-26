using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace EShopOnAbp.PublicBlazor.Data;

public class PublicBlazorEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public PublicBlazorEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the PublicBlazorDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PublicBlazorDbContext>()
            .Database
            .MigrateAsync();
    }
}
