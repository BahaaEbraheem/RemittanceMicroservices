using EShopOnAbp.CurrencyService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EShopOnAbp.CurrencyService;

public abstract class CurrencyServiceController : AbpControllerBase
{
    protected CurrencyServiceController()
    {
        LocalizationResource = typeof(CurrencyServiceResource);
    }
}
