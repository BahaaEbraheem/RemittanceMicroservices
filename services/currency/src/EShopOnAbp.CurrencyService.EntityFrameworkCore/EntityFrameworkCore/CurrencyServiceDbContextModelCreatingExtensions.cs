using EShopOnAbp.CurrencyService.Currencies;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EShopOnAbp.CurrencyService.EntityFrameworkCore;

public static class CurrencyServiceDbContextModelCreatingExtensions
{
    public static void ConfigureCurrencyService(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        builder.Entity<Currency>(b => {

            b.ToTable(CurrencyServiceDbProperties.DbTablePrefix + "Currencies" + CurrencyServiceDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(x => new { x.Id });

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Symbol).IsRequired();
            b.HasIndex(e => new { e.Name, e.Symbol }).IsUnique();


        });


        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(CurrencyServiceDbProperties.DbTablePrefix + "Questions", CurrencyServiceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
