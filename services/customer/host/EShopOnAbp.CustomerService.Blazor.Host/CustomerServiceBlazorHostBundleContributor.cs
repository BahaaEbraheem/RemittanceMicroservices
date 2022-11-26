using Volo.Abp.Bundling;

namespace EShopOnAbp.CustomerService.Blazor.Host;

public class CustomerServiceBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
