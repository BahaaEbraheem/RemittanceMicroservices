using System;
using System.IO;
using EShopOnAbp.CustomerService;
using EShopOnAbp.CustomerService.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EShopOnAbp.CustomerService.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class CustomerServiceDbContextFactory : IDesignTimeDbContextFactory<CustomerServiceDbContext>
    {
        public CustomerServiceDbContext CreateDbContext(string[] args)
        {
            //CurrencyServiceEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CustomerServiceDbContext>()
                .UseSqlServer(
                configuration.GetConnectionString(CustomerServiceDbProperties.ConnectionStringName),
                b =>
                {
                    b.MigrationsHistoryTable("__CustomerService_Migrations");
                });
                 

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new CustomerServiceDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EShopOnAbp.CustomerService.HttpApi.Host/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
