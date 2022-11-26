using EShopOnAbp.CurrencyService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShopOnAbp.CurrencyService.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CurrencyServicePageModel : AbpPageModel
{
    protected CurrencyServicePageModel()
    {
        LocalizationResourceType = typeof(CurrencyServiceResource);
        ObjectMapperContext = typeof(CurrencyServiceWebModule);
    }
}
