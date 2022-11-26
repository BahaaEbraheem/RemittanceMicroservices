﻿using EShopOnAbp.CustomerService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CustomerService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CustomerServiceEntityFrameworkCoreTestModule)
    )]
public class CustomerServiceDomainTestModule : AbpModule
{

}
