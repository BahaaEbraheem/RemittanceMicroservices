using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EShopOnAbp.CustomerService.EntityFrameworkCore;

public class CustomerServiceHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CustomerServiceHttpApiHostMigrationsDbContext>
{
    public CustomerServiceHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CustomerServiceHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("CustomerService"));

        return new CustomerServiceHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
