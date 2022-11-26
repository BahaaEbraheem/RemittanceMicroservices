using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EShopOnAbp.CurrencyService.MongoDB;

public static class CurrencyServiceMongoDbContextExtensions
{
    public static void ConfigureCurrencyService(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
