using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EShopOnAbp.CustomerService;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class CustomerServiceInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CustomerServiceInstallerModule>();
        });
    }
}
