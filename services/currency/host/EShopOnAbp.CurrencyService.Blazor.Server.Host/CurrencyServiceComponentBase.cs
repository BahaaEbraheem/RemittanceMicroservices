using EShopOnAbp.CurrencyService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EShopOnAbp.CurrencyService.Blazor.Server.Host;

public abstract class CurrencyServiceComponentBase : AbpComponentBase
{
    protected CurrencyServiceComponentBase()
    {
        LocalizationResource = typeof(CurrencyServiceResource);
    }
}
