using EShopOnAbp.CurrencyService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EShopOnAbp.CurrencyService.Permissions;

public class CurrencyServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CurrencyServicePermissions.GroupName, L("Permission:CurrencyService"));


        var currenciesPermission = myGroup.AddPermission(CurrencyServicePermissions.Currencies.Default, L("Permission:Currencies"));
        currenciesPermission.AddChild(CurrencyServicePermissions.Currencies.Create, L("Permission:Currencies.Create"));
        currenciesPermission.AddChild(CurrencyServicePermissions.Currencies.Edit, L("Permission:Currencies.Edit"));
        currenciesPermission.AddChild(CurrencyServicePermissions.Currencies.Delete, L("Permission:Currencies.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CurrencyServiceResource>(name);
    }
}
