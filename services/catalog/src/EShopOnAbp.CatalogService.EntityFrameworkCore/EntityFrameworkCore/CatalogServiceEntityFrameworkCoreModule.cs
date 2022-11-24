using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore;
using EShopOnAbp.CatalogService.Products;

namespace EShopOnAbp.CatalogService.EntityFrameworkCore
{
    [DependsOn(
        typeof(CatalogServiceDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class CatalogServiceEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CatalogServiceDbContext>(options =>
            {
                options.AddDefaultRepositories();
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure<CatalogServiceDbContext>(c =>
                {
                    c.UseSqlServer(b =>
                    {
                        b.MigrationsHistoryTable("__CatalogService_Migrations");
                    });
                });
            });
        }
    }
}
