using EShopOnAbp.CatalogService.EntityFrameworkCore;
using EShopOnAbp.CatalogService.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EShopOnAbp.CatalogService.EntityFrameworkCore
{
    [ConnectionStringName(CatalogServiceDbProperties.ConnectionStringName)]
    public class CatalogServiceDbContext : AbpDbContext<CatalogServiceDbContext>, ICatalogServiceDbContext
    {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Include modules to your migration db context */

            modelBuilder.ConfigureCatalogService();
            /* Configure your own tables/entities inside here */


         

        }


    }
}