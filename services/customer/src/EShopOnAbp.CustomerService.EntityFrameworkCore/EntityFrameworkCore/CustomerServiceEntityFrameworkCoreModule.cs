using EShopOnAbp.CustomerService.Customers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CustomerService.EntityFrameworkCore;

[DependsOn(
    typeof(CustomerServiceDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CustomerServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
     


        context.Services.AddAbpDbContext<CustomerServiceDbContext>(options =>
            {
                options.AddRepository<Customer, EfCoreCustomerRepository>();

                options.AddDefaultRepositories(includeAllEntities: true);

            });
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also OrderingServiceMigrationsDbContextFactory for EF Core tooling. */
            options.Configure<CustomerServiceDbContext>(c =>
            {
                c.UseSqlServer(b =>
                {
                    //b.MigrationsHistoryTable("__CurrencyService_Migrations");
                    b.MigrationsHistoryTable("__CustomerService_Migrations");


                });
            });
        });
    } 
}
