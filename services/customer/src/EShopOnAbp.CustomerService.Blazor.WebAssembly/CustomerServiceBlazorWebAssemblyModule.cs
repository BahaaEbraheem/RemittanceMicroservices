using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CustomerService.Blazor.WebAssembly;

[DependsOn(
    typeof(CustomerServiceBlazorModule),
    typeof(CustomerServiceHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CustomerServiceBlazorWebAssemblyModule : AbpModule
{

}
