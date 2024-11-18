using Microsoft.EntityFrameworkCore;

namespace UserProfileMicroservice.WebHost.Helpers;

public static class MigrationManager
{
    public static async Task<IHost> MigrateDatabaseAsync<T>(this IHost host)
    where T : DbContext
    {
        using var scope = host.Services.CreateScope();
        var appContext = scope.ServiceProvider.GetService<T>();

        if (appContext != null)
            await appContext.Database.MigrateAsync();

        return host;
    }
}