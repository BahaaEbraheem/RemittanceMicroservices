using EShopOnAbp.CurrencyService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShopOnAbp.CurrencyService.Pages;

public abstract class CurrencyServicePageModel : AbpPageModel
{
    protected CurrencyServicePageModel()
    {
        LocalizationResourceType = typeof(CurrencyServiceResource);
    }
}
