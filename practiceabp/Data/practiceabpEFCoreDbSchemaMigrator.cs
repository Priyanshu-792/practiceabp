using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace practiceabp.Data;

public class practiceabpEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public practiceabpEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the practiceabpDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<practiceabpDbContext>()
            .Database
            .MigrateAsync();
    }
}
