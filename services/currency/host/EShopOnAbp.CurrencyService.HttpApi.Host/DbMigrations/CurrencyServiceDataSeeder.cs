using EShopOnAbp.CurrencyService.Currencies;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace EShopOnAbp.CurrencyService.DbMigrations;

public class CurrencyServiceDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Currency, Guid> _currencyRepository;
    private readonly IGuidGenerator _guidGenerator;

    public CurrencyServiceDataSeeder(
        IGuidGenerator guidGenerator,
        IRepository<Currency, Guid> currencyRepository)
    {
        _currencyRepository = currencyRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await AddCurrenciesAsync();
    }

    private async Task AddCurrenciesAsync()
    {
        if (await _currencyRepository.GetCountAsync() > 0)
        {
            return;
        }

        if (await _currencyRepository.GetCountAsync() > 0)
        {
            return;
        }


        await _currencyRepository.InsertAsync(
            new Currency
            (
              _guidGenerator.Create(),
               "United Kingdom Pound",
                "GBP",
               "£"

            ),
            autoSave: true
        );


        await _currencyRepository.InsertAsync(

        new Currency
       (
              _guidGenerator.Create(),
           "United States Dollar",
           "USD",
            "$"

       )
        );

        await _currencyRepository.InsertAsync(
        new Currency
        (
              _guidGenerator.Create(),
            "Syrian Pound",
          "SYP",
            "£"

        ), autoSave: true
        );

        await _currencyRepository.InsertAsync(
        new Currency(
            _guidGenerator.Create(),
            "Russia Ruble",
             "RUB",
             "₽"
             ), autoSave: true


       );

    }
}