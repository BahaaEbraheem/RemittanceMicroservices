using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CurrencyService.Blazor.WebAssembly;

[DependsOn(
    typeof(CurrencyServiceBlazorModule),
    typeof(CurrencyServiceHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CurrencyServiceBlazorWebAssemblyModule : AbpModule
{

}
