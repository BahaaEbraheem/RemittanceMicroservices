using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
    typeof(CurrencyServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CurrencyServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Currency";
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // context.Services.AddHttpClientProxies(
         //    typeof(CurrencyServiceApplicationContractsModule).Assembly,
         //    CurrencyServiceRemoteServiceConsts.RemoteServiceName
        // );
          context.Services.AddHttpClientProxies(
                typeof(CurrencyServiceApplicationContractsModule).Assembly,
                 CurrencyServiceRemoteServiceConsts.RemoteServiceName
                //RemoteServiceName
            );
 
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CurrencyServiceHttpApiClientModule>();
        });

    }
}
