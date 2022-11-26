﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CustomerService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CustomerServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CustomerServiceConsoleApiClientModule : AbpModule
{

}
