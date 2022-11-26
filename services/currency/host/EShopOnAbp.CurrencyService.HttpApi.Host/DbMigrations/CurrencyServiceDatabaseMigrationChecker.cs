using EShopOnAbp.CurrencyService.EntityFrameworkCore;
using System;
using EShopOnAbp.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Data;
using System.Threading.Tasks;
using EShopOnAbp.CurrencyService.Currencies;
using Volo.Abp.Guids;
using Volo.Abp.Domain.Repositories;

namespace EShopOnAbp.CurrencyService.DbMigrations;

public class CurrencyServiceDatabaseMigrationChecker
    : PendingEfCoreMigrationsChecker<CurrencyServiceDbContext>
{
    private readonly CurrencyManager _currencyManager;
    private readonly IRepository<Currency, Guid> _currencyRepository;
    private readonly IGuidGenerator _guidGenerator;
    public CurrencyServiceDatabaseMigrationChecker(
         IRepository<Currency, Guid> currencyRepository,
        CurrencyManager currencyManager,
        IGuidGenerator guidGenerator,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
          IAbpDistributedLock abpDistributedLock)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            CurrencyServiceDbProperties.ConnectionStringName)
    {
        _currencyRepository = currencyRepository;
        _currencyManager = currencyManager;
        _guidGenerator = guidGenerator;
    }
    //public override async Task CheckAndApplyDatabaseMigrationsAsync()
    //{
    //    await base.CheckAndApplyDatabaseMigrationsAsync();

    //    await TryAsync(async () => await SeedCurrenciesAsync());
    //}
    //private async Task SeedCurrenciesAsync()
    //{
    //    if (await _currencyRepository.GetCountAsync() > 0)
    //    {
    //        return;
    //    }


    //    await _currencyRepository.InsertAsync(
    //        new Currency
    //    (
    //          _guidGenerator.Create(),
    //           "United Kingdom Pound",
    //            "GBP",
    //    "£"
    //    ),
    //        autoSave: true
    //    );


    //    await _currencyRepository.InsertAsync(

    //    new Currency
    //    (
    //          _guidGenerator.Create(),
    //       "United States Dollar",
    //    "USD",
    //    "$"

    //   )
    //    );

    //    await _currencyRepository.InsertAsync(
    //    new Currency
    //    (
    //          _guidGenerator.Create(),
    //        "Syrian Pound",
    //      "SYP",
    //    "£"
    //    ), autoSave: true
    //    );

    //    await _currencyRepository.InsertAsync(
    //    new Currency(
    //        _guidGenerator.Create(),
    //        "Russia Ruble",
    //         "RUB",
    //         "₽"
    //         ), autoSave: true





    //   );

    //}
}