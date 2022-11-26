using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EShopOnAbp.CustomerService;

[DependsOn(
    typeof(CustomerServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CustomerServiceHttpApiClientModule : AbpModule
{
 public const string RemoteServiceName = "Customer";
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CustomerServiceApplicationContractsModule).Assembly,
            CustomerServiceRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CustomerServiceHttpApiClientModule>();
        });

    }
}
