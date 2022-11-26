using AutoMapper;
using EShopOnAbp.CurrencyService.Currencies;

namespace EShopOnAbp.CurrencyService;

public class CurrencyServiceApplicationAutoMapperProfile : Profile
{
    public CurrencyServiceApplicationAutoMapperProfile()
    {
        CreateMap<Currency, CurrencyDto>()
        .ForMember(model => model.LastModifierId, option => option.Ignore())
        .ForMember(model => model.CreatorId, option => option.Ignore())
        .ForMember(model => model.CreationTime, option => option.Ignore())
        .ForMember(model => model.LastModificationTime, option => option.Ignore());
        CreateMap<CreateUpdateCurrencyDto, Currency>()
              .ForMember(model => model.ExtraProperties, option => option.Ignore())
             .ForMember(model => model.ConcurrencyStamp, option => option.Ignore())
             .ForMember(model => model.Id, option => option.Ignore());
        CreateMap<CurrencyPagedAndSortedResultRequestDto, Currency>()
           .ForMember(model => model.ExtraProperties, option => option.Ignore())
          .ForMember(model => model.ConcurrencyStamp, option => option.Ignore())
          .ForMember(model => model.Id, option => option.Ignore());


    }
}
