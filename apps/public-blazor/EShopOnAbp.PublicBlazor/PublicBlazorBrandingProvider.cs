using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EShopOnAbp.PublicBlazor;

[Dependency(ReplaceServices = true)]
public class PublicBlazorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "PublicBlazor";
}
