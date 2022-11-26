using EShopOnAbp.CurrencyService.Currencies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CurrencyService.EntityFrameworkCore;

[DependsOn(
    typeof(CurrencyServiceDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CurrencyServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CurrencyServiceDbContext>(options =>
        {
            options.AddRepository<Currency, EfCoreCurrencyRepository>();

            options.AddDefaultRepositories(includeAllEntities: true);

        });
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also OrderingServiceMigrationsDbContextFactory for EF Core tooling. */
            options.Configure<CurrencyServiceDbContext>(c =>
            {

                c.UseSqlServer(b =>
                {
                    //b.MigrationsHistoryTable("__CurrencyService_Migrations");
                    b.MigrationsHistoryTable("__CurrencyService_Migrations");
                });
            });
        });

    }

}
