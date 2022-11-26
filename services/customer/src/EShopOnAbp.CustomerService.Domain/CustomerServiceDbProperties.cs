namespace EShopOnAbp.CustomerService;

public static class CustomerServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "CustomerService";
}
