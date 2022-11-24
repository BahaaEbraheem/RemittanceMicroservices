﻿namespace EShopOnAbp.CmskitService;

public static class CmskitServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = string.Empty;

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "CmskitService";
}
