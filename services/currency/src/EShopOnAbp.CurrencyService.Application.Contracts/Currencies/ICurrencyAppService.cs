using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace EShopOnAbp.CurrencyService.Currencies
{
    public interface ICurrencyAppService :
         ICrudAppService< //Defines CRUD methods
             CurrencyDto, //Used to show currencies
             Guid, //Primary key of the currency entity
             CurrencyPagedAndSortedResultRequestDto, //Used for paging/sorting
             CreateUpdateCurrencyDto> //Used to create/update a currency
    {
        //Task<PagedResultDto<CurrencyDto>> GetListAsync(CurrencyPagedAndSortedResultRequestDto input);
        ////Task<ListResultDto<CurrencyDto>> GetListAsync();
        //Task<CurrencyDto> GetAsync(Guid id);

        //new Task<CurrencyDto> CreateAsync(CreateUpdateCurrencyDto input);

        //Task<CurrencyDto> UpdateAsync(Guid id, CreateUpdateCurrencyDto input);

        //Task DeleteAsync(Guid id);
    }


}
