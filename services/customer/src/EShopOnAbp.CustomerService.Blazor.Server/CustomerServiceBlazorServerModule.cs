using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CustomerService.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CustomerServiceBlazorModule)
    )]
public class CustomerServiceBlazorServerModule : AbpModule
{

}
