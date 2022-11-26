using EShopOnAbp.CustomerService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EShopOnAbp.CustomerService.Permissions;

public class CustomerServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CustomerServicePermissions.GroupName, L("Permission:CustomerService"));

        var customersPermission = myGroup.AddPermission(CustomerServicePermissions.Customers.Default, L("Permission:Customers"));
        customersPermission.AddChild(CustomerServicePermissions.Customers.Create, L("Permission:Customers.Create"));
        customersPermission.AddChild(CustomerServicePermissions.Customers.Edit, L("Permission:Customers.Edit"));
        customersPermission.AddChild(CustomerServicePermissions.Customers.Delete, L("Permission:Customers.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CustomerServiceResource>(name);
    }
}
