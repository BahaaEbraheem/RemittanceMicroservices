using EShopOnAbp.CustomerService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShopOnAbp.CustomerService.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CustomerServicePageModel : AbpPageModel
{
    protected CustomerServicePageModel()
    {
        LocalizationResourceType = typeof(CustomerServiceResource);
        ObjectMapperContext = typeof(CustomerServiceWebModule);
    }
}
