using EShopOnAbp.CustomerService.Localization;
using Volo.Abp.Application.Services;

namespace EShopOnAbp.CustomerService;

public abstract class CustomerServiceAppService : ApplicationService
{
    protected CustomerServiceAppService()
    {
        LocalizationResource = typeof(CustomerServiceResource);
        ObjectMapperContext = typeof(CustomerServiceApplicationModule);
    }
}
