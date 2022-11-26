using EShopOnAbp.PublicBlazor.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EShopOnAbp.PublicBlazor;

public abstract class PublicBlazorComponentBase : AbpComponentBase
{
    protected PublicBlazorComponentBase()
    {
        LocalizationResource = typeof(PublicBlazorResource);
    }
}
