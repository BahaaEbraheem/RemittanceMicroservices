using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace EShopOnAbp.CurrencyService.Currencies
{
    public class CurrencyManager : DomainService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyManager(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }


        public Task IsCurrencyUsedBeforInRemittance(Guid id)
        {
            Check.NotNull(id, nameof(id));
            return Task.CompletedTask;
        }
    }
}
