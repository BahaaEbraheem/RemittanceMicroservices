﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EShopOnAbp.CurrencyService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CurrencyServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CurrencyServiceConsoleApiClientModule : AbpModule
{

}
