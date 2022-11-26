using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EShopOnAbp.CurrencyService.MongoDB;

[ConnectionStringName(CurrencyServiceDbProperties.ConnectionStringName)]
public class CurrencyServiceMongoDbContext : AbpMongoDbContext, ICurrencyServiceMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCurrencyService();
    }
}
