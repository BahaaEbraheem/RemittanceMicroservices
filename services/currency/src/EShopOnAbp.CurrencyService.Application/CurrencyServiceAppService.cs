﻿using EShopOnAbp.CurrencyService.Localization;
using Volo.Abp.Application.Services;

namespace EShopOnAbp.CurrencyService;

public abstract class CurrencyServiceAppService : ApplicationService
{
    protected CurrencyServiceAppService()
    {
        LocalizationResource = typeof(CurrencyServiceResource);
        ObjectMapperContext = typeof(CurrencyServiceApplicationModule);
    }
}
