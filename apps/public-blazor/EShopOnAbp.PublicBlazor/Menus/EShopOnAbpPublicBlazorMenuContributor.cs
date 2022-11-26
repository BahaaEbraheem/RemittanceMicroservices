using System;
using System.IO;
using System.Threading.Tasks;
using EShopOnAbp.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace EShopOnAbp.PublicBlazor.Menus
{
    public class EShopOnAbpPublicBlazorMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public EShopOnAbpPublicBlazorMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<EShopOnAbpResource>();

            ////Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    EShopOnAbpPublicBlazorMenus.HomePage,
                    l["Menu:Home"],
                    "~/",
                    icon: "fa fa-home",
                    order: 0
                )
            );
            // Currencies
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    EShopOnAbpPublicBlazorMenus.Currencies,
                    l["Menu:Currencies"],
                    url: "/currencies",
                    icon: "fa fa-home",
                    order: 0
                )
            ).AddItem(
                new ApplicationMenuItem(
                    EShopOnAbpPublicBlazorMenus.Customers,
                    l["Menu:Customers"],
                    url: "/customers",
                    icon: "fa fa-home",
                    order: 0
                )
                );


            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "~";
            var uiResource = context.GetLocalizer<AbpUiResource>();
            var accountResource = context.GetLocalizer<AccountResource>();
            var eShopResource = context.GetLocalizer<EShopOnAbpResource>();
            //var eShopResource = context.GetLocalizer<CurrencyResource>();
            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"], $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("MyOrders", eShopResource["Menu:MyOrders"], $"/MyOrders", icon: "fa fa-shopping-cart", order: 2, null).RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}