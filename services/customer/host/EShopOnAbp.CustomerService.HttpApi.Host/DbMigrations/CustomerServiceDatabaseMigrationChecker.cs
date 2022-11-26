using EShopOnAbp.CustomerService.EntityFrameworkCore;
using System;
using EShopOnAbp.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Data;
using System.Threading.Tasks;
using EShopOnAbp.CustomerService.Customers;
using Volo.Abp.Guids;
using Volo.Abp.Domain.Repositories;

namespace EShopOnAbp.CustomerService.DbMigrations;

public class CustomerServiceDatabaseMigrationChecker
    : PendingEfCoreMigrationsChecker<CustomerServiceDbContext>
{
    private readonly CustomerManager _CustomerManager;
    private readonly IRepository<Customer, Guid> _CustomerRepository;
    private readonly IGuidGenerator _guidGenerator;
    public CustomerServiceDatabaseMigrationChecker(
         IRepository<Customer, Guid> CustomerRepository,
        CustomerManager CustomerManager,
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
            CustomerServiceDbProperties.ConnectionStringName)
    {
        _CustomerRepository = CustomerRepository;
        _CustomerManager = CustomerManager;
        _guidGenerator = guidGenerator;
    }
    //public override async Task CheckAndApplyDatabaseMigrationsAsync()
    //{
    //    await base.CheckAndApplyDatabaseMigrationsAsync();

    //    await TryAsync(async () => await SeedCurrenciesAsync());
    //}
    //private async Task SeedCurrenciesAsync()
    //{
    //    if (await _CustomerRepository.GetCountAsync() > 0)
    //    {
    //        return;
    //    }


    //    await _CustomerRepository.InsertAsync(
    //        new Customer
    //    (
    //          _guidGenerator.Create(),
    //           "United Kingdom Pound",
    //            "GBP",
    //    "£"
    //    ),
    //        autoSave: true
    //    );


    //    await _CustomerRepository.InsertAsync(

    //    new Customer
    //    (
    //          _guidGenerator.Create(),
    //       "United States Dollar",
    //    "USD",
    //    "$"

    //   )
    //    );

    //    await _CustomerRepository.InsertAsync(
    //    new Customer
    //    (
    //          _guidGenerator.Create(),
    //        "Syrian Pound",
    //      "SYP",
    //    "£"
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