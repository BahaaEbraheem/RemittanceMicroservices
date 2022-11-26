using AutoMapper;
using EShopOnAbp.CurrencyService.Currencies;

namespace EShopOnAbp.CurrencyService.Blazor;

public class CurrencyServiceBlazorAutoMapperProfile : Profile
{
    public CurrencyServiceBlazorAutoMapperProfile()
    {

        CreateMap<Currency, CurrencyDto>()
             .ForMember(model => model.LastModifierId, option => option.Ignore())
             .ForMember(model => model.CreatorId, option => option.Ignore())
             .ForMember(model => model.CreationTime, option => option.Ignore())
             .ForMember(model => model.LastModificationTime, option => option.Ignore());
    }
}
