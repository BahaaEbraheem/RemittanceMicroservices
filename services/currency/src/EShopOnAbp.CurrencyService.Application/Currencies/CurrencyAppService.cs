using EShopOnAbp.CurrencyService.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using EShopOnAbp.CurrencyService.Permissions;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Volo.Abp.ObjectMapping;
using Volo.Abp.DependencyInjection;
using static System.Reflection.Metadata.BlobBuilder;
using Volo.Abp;
using EShopOnAbp.CurrencyService;
using Volo.Abp.Localization;

namespace EShopOnAbp.CurrencyService.Currencies
{
    //[Authorize(CurrencyServicePermissions.Currencies.Default)]

    public class CurrencyAppService : 
        CrudAppService<
               Currency, //The Currency entity
            CurrencyDto, //Used to show Currencies
            Guid, //Primary key of the Currency entity
            CurrencyPagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCurrencyDto>, //Used to create/update a Currency
        ICurrencyAppService//implement the ICurrencyAppService
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyAppService(
     
            IRepository<Currency, Guid> repository,
            ICurrencyRepository currencyRepository
       )
    : base(repository)
        {
 
            _currencyRepository = currencyRepository;
        }


       public override async Task<PagedResultDto<CurrencyDto>> GetListAsync(CurrencyPagedAndSortedResultRequestDto input)
        {
            var filter = ObjectMapper.Map<CurrencyPagedAndSortedResultRequestDto, Currency>(input);
            var sorting = (string.IsNullOrEmpty(input.Sorting) ? "Name DESC" : input.Sorting).Replace("ShortName", "Name");
            var currencies = await _currencyRepository.GetListAsync(input.SkipCount, input.MaxResultCount, sorting, filter);
            var totalCount = await _currencyRepository.GetTotalCountAsync(filter);
            return new PagedResultDto<CurrencyDto>(totalCount, ObjectMapper.Map<List<Currency>, List<CurrencyDto>>(currencies));
        }


        //public async Task<ListResultDto<CurrencyDto>> GetListAsync()
        //{
        //    var products = await _currencyRepository.GetListAsync();
        //    return new ListResultDto<CurrencyDto>(
        //        ObjectMapper.Map<List<Currency>, List<CurrencyDto>>(products)
        //    );
        //}

        //[Authorize(CurrencyServicePermissions.Currencies.Create)]
        public override Task<CurrencyDto> CreateAsync(CreateUpdateCurrencyDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("");
            }
            Check.NotNullOrWhiteSpace(input.Name, nameof(input.Name));
            Check.NotNullOrWhiteSpace(input.Symbol, nameof(input.Symbol));
            var existingCurrency = _currencyRepository.FindByNameAndSymbolAsync(input.Name, input.Symbol).Result;
            if (existingCurrency != null)
            {
                throw new CurrencyAlreadyExistsException(existingCurrency.Name);
            }
            return base.CreateAsync(input);
        }




        //[Authorize(CurrencyServicePermissions.Currencies.Edit)]
        public override async Task<CurrencyDto> UpdateAsync(Guid id, CreateUpdateCurrencyDto input)
        {

            if (input == null)
            {
                throw new ArgumentNullException("");
            }
            Check.NotNullOrWhiteSpace(id.ToString(), nameof(id));
            //check if currency exist befor in tables
            var existingCurrency = await _currencyRepository.FindByNameAndSymbolAsync(input.Name, input.Symbol);
            if ((existingCurrency != null && !existingCurrency.Name.Contains(input.Name))
               || (existingCurrency != null && !existingCurrency.Symbol.Contains(input.Symbol)))
            {
                throw new CurrencyAlreadyExistsException(existingCurrency.Name);
            }
            return await base.UpdateAsync(id, input);
        }



        //[Authorize(CurrencyServicePermissions.Currencies.Delete)]
        public override Task DeleteAsync(Guid id)
        {
            //check if this currency using by any remittance
            //_currencyManager.IsCurrencyUsedBeforInRemittance(id);
            return base.DeleteAsync(id);
        }

   
    }
}


