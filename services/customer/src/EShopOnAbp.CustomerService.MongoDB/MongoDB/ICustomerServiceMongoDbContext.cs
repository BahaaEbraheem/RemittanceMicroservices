using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EShopOnAbp.CustomerService.MongoDB;

[ConnectionStringName(CustomerServiceDbProperties.ConnectionStringName)]
public interface ICustomerServiceMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
