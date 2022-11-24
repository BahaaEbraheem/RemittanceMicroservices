namespace EShopOnAbp.CatalogService
{
    public static class CatalogServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = string.Empty;

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CatalogService";
    }
}
