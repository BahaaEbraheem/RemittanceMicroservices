using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EShopOnAbp.CustomerService;

[Dependency(ReplaceServices = true)]
public class CustomerServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CustomerService";
}
