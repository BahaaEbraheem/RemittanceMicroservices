using Volo.Abp.Modularity;

namespace EShopOnAbp.CustomerService;

[DependsOn(
    typeof(CustomerServiceApplicationModule),
    typeof(CustomerServiceDomainTestModule)
    )]
public class CustomerServiceApplicationTestModule : AbpModule
{

}
