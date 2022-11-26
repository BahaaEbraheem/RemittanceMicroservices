using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
    typeof(CurrencyServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CurrencyServiceApplicationContractsModule : AbpModule
{

}
