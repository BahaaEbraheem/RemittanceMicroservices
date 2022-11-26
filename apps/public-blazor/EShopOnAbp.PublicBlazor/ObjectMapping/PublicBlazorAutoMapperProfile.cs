using AutoMapper;
using EShopOnAbp.CurrencyService.Currencies;
using EShopOnAbp.CustomerService.Customers;

namespace EShopOnAbp.PublicBlazor.ObjectMapping;

public class PublicBlazorAutoMapperProfile : Profile
{
    public PublicBlazorAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<Currency, CurrencyDto>()
          .ForMember(model => model.LastModifierId, option => option.Ignore())
          .ForMember(model => model.CreatorId, option => option.Ignore())
          .ForMember(model => model.CreationTime, option => option.Ignore())
          .ForMember(model => model.LastModificationTime, option => option.Ignore());
        CreateMap<CurrencyDto, CreateUpdateCurrencyDto>();
        CreateMap<CustomerDto, CreateUpdateCustomerDto>();

        CreateMap<CreateUpdateCurrencyDto, Currency>()
              .ForMember(model => model.ExtraProperties, option => option.Ignore())
             .ForMember(model => model.ConcurrencyStamp, option => option.Ignore())
             .ForMember(model => model.Id, option => option.Ignore());
        //CreateMap<CurrencyPagedAndSortedResultRequestDto, Currency>()
        //   .ForMember(model => model.ExtraProperties, option => option.Ignore())
        //  .ForMember(model => model.ConcurrencyStamp, option => option.Ignore())
        //  .ForMember(model => model.Id, option => option.Ignore());
   

    }
}
