using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace EShopOnAbp.CustomerService.Web.Menus;

public class CustomerServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CustomerServiceMenus.Prefix, displayName: "CustomerService", "~/CustomerService", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
