using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EShopOnAbp.CustomerService.MongoDB;

[ConnectionStringName(CustomerServiceDbProperties.ConnectionStringName)]
public class CustomerServiceMongoDbContext : AbpMongoDbContext, ICustomerServiceMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCustomerService();
    }
}
