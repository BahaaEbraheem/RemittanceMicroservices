using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EShopOnAbp.CustomerService.EntityFrameworkCore;

public class CustomerServiceHttpApiHostMigrationsDbContext : AbpDbContext<CustomerServiceHttpApiHostMigrationsDbContext>
{
    public CustomerServiceHttpApiHostMigrationsDbContext(DbContextOptions<CustomerServiceHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCustomerService();
    }
}
