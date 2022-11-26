using EShopOnAbp.CurrencyService.Currencies;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EShopOnAbp.CurrencyService.EntityFrameworkCore;

[ConnectionStringName(CurrencyServiceDbProperties.ConnectionStringName)]
public interface ICurrencyServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    public DbSet<Currency> Currencies { get; set; }
}
