using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EShopOnAbp.CurrencyService;

[Dependency(ReplaceServices = true)]
public class CurrencyServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CurrencyService";
}
