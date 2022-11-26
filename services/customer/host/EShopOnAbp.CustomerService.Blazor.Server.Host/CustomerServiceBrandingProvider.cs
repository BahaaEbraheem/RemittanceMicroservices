using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EShopOnAbp.CustomerService.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CustomerServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CustomerService";
}
