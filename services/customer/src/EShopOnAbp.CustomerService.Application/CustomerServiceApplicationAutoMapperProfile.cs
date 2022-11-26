using AutoMapper;
using EShopOnAbp.CustomerService.Customers;

namespace EShopOnAbp.CustomerService;

public class CustomerServiceApplicationAutoMapperProfile : Profile
{
    public CustomerServiceApplicationAutoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>()
    
        .ForMember(model => model.LastModifierId, option => option.Ignore())
        .ForMember(model => model.CreatorId, option => option.Ignore())
        .ForMember(model => model.CreationTime, option => option.Ignore())
        .ForMember(model => model.LastModificationTime, option => option.Ignore());
        CreateMap<CreateUpdateCustomerDto, Customer>()
                .ForMember(model => model.IsDeleted, option => option.Ignore())
                .ForMember(model => model.LastModificationTime, option => option.Ignore())
                .ForMember(model => model.LastModifierId, option => option.Ignore())
                .ForMember(model => model.IsDeleted, option => option.Ignore())
                .ForMember(model => model.CreationTime, option => option.Ignore())
                .ForMember(model => model.CreatorId, option => option.Ignore())
        .ForMember(model => model.DeleterId, option => option.Ignore())
        .ForMember(model => model.DeletionTime, option => option.Ignore())
        .ForMember(model => model.LastModifierId, option => option.Ignore())
          .ForMember(model => model.ExtraProperties, option => option.Ignore())
        .ForMember(model => model.ConcurrencyStamp, option => option.Ignore())
         .ForMember(model => model.Id, option => option.Ignore());
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
