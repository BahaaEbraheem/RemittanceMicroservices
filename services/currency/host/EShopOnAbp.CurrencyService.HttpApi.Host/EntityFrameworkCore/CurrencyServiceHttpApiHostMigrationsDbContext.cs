﻿using EShopOnAbp.CurrencyService.Currencies;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EShopOnAbp.CurrencyService.EntityFrameworkCore;

public class CurrencyServiceHttpApiHostMigrationsDbContext : AbpDbContext<CurrencyServiceHttpApiHostMigrationsDbContext>
{
    public CurrencyServiceHttpApiHostMigrationsDbContext(DbContextOptions<CurrencyServiceHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCurrencyService();
    }
}
