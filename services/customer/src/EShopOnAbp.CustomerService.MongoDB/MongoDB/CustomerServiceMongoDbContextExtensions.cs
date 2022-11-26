using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EShopOnAbp.CustomerService.MongoDB;

public static class CustomerServiceMongoDbContextExtensions
{
    public static void ConfigureCustomerService(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
