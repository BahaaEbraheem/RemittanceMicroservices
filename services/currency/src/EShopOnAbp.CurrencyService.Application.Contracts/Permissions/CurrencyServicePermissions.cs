﻿using Volo.Abp.Reflection;

namespace EShopOnAbp.CurrencyService.Permissions;

public class CurrencyServicePermissions
{
    public const string GroupName = "CurrencyService";
    public static class Currencies
    {
        public const string Default = GroupName + ".Currencies";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CurrencyServicePermissions));
    }
}
