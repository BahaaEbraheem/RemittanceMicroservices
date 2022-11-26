using EShopOnAbp.CustomerService.Customers;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace EShopOnAbp.CustomerService.DbMigrations;

public class CustomerServiceDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Customer, Guid> _CustomerRepository;
    private readonly IGuidGenerator _guidGenerator;

    public CustomerServiceDataSeeder(
        IGuidGenerator guidGenerator,
        IRepository<Customer, Guid> CustomerRepository)
    {
        _CustomerRepository = CustomerRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        //await AddCurrenciesAsync();
    }

    //private async Task AddCurrenciesAsync()
    //{
    //    if (await _CustomerRepository.GetCountAsync() > 0)
    //    {
    //        return;
    //    }

    //    if (await _CustomerRepository.GetCountAsync() > 0)
    //    {
    //        return;
    //    }


    //    await _CustomerRepository.InsertAsync(
    //        new Customer
    //        (
    //          _guidGenerator.Create(),
    //           "United Kingdom Pound",
    //            "GBP",
    //           "£"

    //        ),
    //        autoSave: true
    //    );


    //    await _CustomerRepository.InsertAsync(

    //    new Customer
    //   (
    //          _guidGenerator.Create(),
    //       "United States Dollar",
    //       "USD",
    //        "$"

    //   )
    //    );

    //    await _CustomerRepository.InsertAsync(
    //    new Customer
    //    (
    //          _guidGenerator.Create(),
    //        "Syrian Pound",
    //      "SYP",
    //        "£"

    //    ), autoSave: true
    //    );

    //    await _CustomerRepository.InsertAsync(
    //    new Customer(
    //        _guidGenerator.Create(),
    //        "Russia Ruble",
    //         "RUB",
    //         "₽"
    //         ), autoSave: true


    //   );

    //}
}