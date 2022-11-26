using EShopOnAbp.CurrencyService.Currencies;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace EShopOnAbp.CurrencyService;

public class CurrencyServiceDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<Currency, Guid> _currencyRepository;


    public CurrencyServiceDataSeedContributor(
        IGuidGenerator guidGenerator, ICurrentTenant currentTenant
        , IRepository<Currency, Guid> currencyRepository)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _currencyRepository = currencyRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Instead of returning the Task.CompletedTask, you can insert your test data
         * at this point!
         */
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





       );if (await _currencyRepository.GetCountAsync() > 0)
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
