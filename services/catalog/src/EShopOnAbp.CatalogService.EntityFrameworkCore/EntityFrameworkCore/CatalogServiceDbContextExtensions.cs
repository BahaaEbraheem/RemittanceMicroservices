using EShopOnAbp.CatalogService.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EShopOnAbp.CatalogService.EntityFrameworkCore
{
    public static class CatalogServiceDbContextExtensions
    {
        public static void ConfigureCatalogService(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Product>(x =>
            {
                x.ToTable(CatalogServiceDbProperties.DbTablePrefix + "Products", CatalogServiceDbProperties.DbSchema);
                x.ConfigureByConvention(); //auto configure for the base class props
            });
        }
    }
}
