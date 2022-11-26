using System;
using System.IO;
using EShopOnAbp.CurrencyService;
using EShopOnAbp.CurrencyService.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp.EntityFrameworkCore.SqlServer;

namespace EShopOnAbp.CurrencyService.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class CurrencyServiceDbContextFactory : IDesignTimeDbContextFactory<CurrencyServiceDbContext>
    {
        public CurrencyServiceDbContext CreateDbContext(string[] args)
        {
            //CurrencyServiceEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CurrencyServiceDbContext>()
                .UseSqlServer(
                configuration.GetConnectionString(CurrencyServiceDbProperties.ConnectionStringName),
                b =>
                {
                    b.MigrationsHistoryTable("__CurrencyService_Migrations");
                });
                 

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new CurrencyServiceDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EShopOnAbp.CurrencyService.HttpApi.Host/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
