using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EShopOnAbp.PublicBlazor.Data;

public class PublicBlazorDbContextFactory : IDesignTimeDbContextFactory<PublicBlazorDbContext>
{
    public PublicBlazorDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PublicBlazorDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new PublicBlazorDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
