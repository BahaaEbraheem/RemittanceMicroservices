using Volo.Abp.Bundling;

namespace EShopOnAbp.CurrencyService.Blazor.Host;

public class CurrencyServiceBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
