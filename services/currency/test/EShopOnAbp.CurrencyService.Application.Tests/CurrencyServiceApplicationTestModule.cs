using Volo.Abp.Modularity;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
    typeof(CurrencyServiceApplicationModule),
    typeof(CurrencyServiceDomainTestModule)
    )]
public class CurrencyServiceApplicationTestModule : AbpModule
{

}
