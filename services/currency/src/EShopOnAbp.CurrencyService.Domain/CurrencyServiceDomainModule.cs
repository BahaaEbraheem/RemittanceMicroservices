using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CurrencyServiceDomainSharedModule)
)]
public class CurrencyServiceDomainModule : AbpModule
{

}
