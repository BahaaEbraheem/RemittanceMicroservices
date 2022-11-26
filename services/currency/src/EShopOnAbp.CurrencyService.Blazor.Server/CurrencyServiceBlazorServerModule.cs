using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CurrencyService.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CurrencyServiceBlazorModule)
    )]
public class CurrencyServiceBlazorServerModule : AbpModule
{

}
