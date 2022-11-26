using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Users;

namespace EShopOnAbp.PublicBlazor.Menus
{
    public class EShopOnAbpPublicBlazorToolbarContributor : IToolbarContributor
    {
        public virtual Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return Task.CompletedTask;
            }

            //context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(CartWidgetViewComponent), order: 0));

            //if (!context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            //{
            //    context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginLinkViewComponent)));
            //}

            return Task.CompletedTask;
        }
    }
}
