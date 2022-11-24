using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EShopOnAbp.CatalogService.EntityFrameworkCore
{
    [ConnectionStringName(CatalogServiceDbProperties.ConnectionStringName)]
    public interface ICatalogServiceDbContext : IEfCoreDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
