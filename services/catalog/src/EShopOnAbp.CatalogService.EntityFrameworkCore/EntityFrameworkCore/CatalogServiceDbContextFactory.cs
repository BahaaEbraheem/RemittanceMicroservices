using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp.EntityFrameworkCore.SqlServer;

namespace EShopOnAbp.CatalogService.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class CatalogServiceDbContextFactory : IDesignTimeDbContextFactory<CatalogServiceDbContext>
    {
        public CatalogServiceDbContext CreateDbContext(string[] args)
        {
            //CatalogServiceEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CatalogServiceDbContext>()
                .UseSqlServer(
                configuration.GetConnectionString(CatalogServiceDbProperties.ConnectionStringName),
                b =>
                {
                    b.MigrationsHistoryTable("__CatalogService_Migrations");
                });
                 

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new CatalogServiceDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EShopOnAbp.CatalogService.HttpApi.Host/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
