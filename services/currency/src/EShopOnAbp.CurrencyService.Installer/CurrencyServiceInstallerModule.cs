using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class CurrencyServiceInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CurrencyServiceInstallerModule>();
        });
    }
}
