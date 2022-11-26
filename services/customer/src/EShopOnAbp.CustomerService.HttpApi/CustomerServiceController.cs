using EShopOnAbp.CustomerService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EShopOnAbp.CustomerService;

public abstract class CustomerServiceController : AbpControllerBase
{
    protected CustomerServiceController()
    {
        LocalizationResource = typeof(CustomerServiceResource);
    }
}
