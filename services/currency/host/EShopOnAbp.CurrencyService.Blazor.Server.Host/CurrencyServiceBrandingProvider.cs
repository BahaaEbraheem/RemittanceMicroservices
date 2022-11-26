using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EShopOnAbp.CurrencyService.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CurrencyServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CurrencyService";
}
