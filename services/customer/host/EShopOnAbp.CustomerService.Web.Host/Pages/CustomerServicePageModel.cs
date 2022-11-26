using EShopOnAbp.CustomerService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EShopOnAbp.CustomerService.Pages;

public abstract class CustomerServicePageModel : AbpPageModel
{
    protected CustomerServicePageModel()
    {
        LocalizationResourceType = typeof(CustomerServiceResource);
    }
}
