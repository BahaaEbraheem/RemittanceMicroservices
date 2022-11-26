using EShopOnAbp.CustomerService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EShopOnAbp.CustomerService.Blazor.Server.Host;

public abstract class CustomerServiceComponentBase : AbpComponentBase
{
    protected CustomerServiceComponentBase()
    {
        LocalizationResource = typeof(CustomerServiceResource);
    }
}
