using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace EShopOnAbp.CurrencyService.Blazor.Menus;

public class CurrencyServiceMenuContributor : IMenuContributor
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
        //context.Menu.AddItem(new ApplicationMenuItem(CurrencyServiceMenus.Prefix, displayName: "CurrencyService", "/CurrencyService", icon: "fa fa-globe"));
        //context.Menu.AddItem(new ApplicationMenuItem(CurrencyServiceMenus.Currencies, displayName: "Currencies", "/currencies", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
