﻿using AutoMapper;
using EShopOnAbp.CustomerService.Customers;

namespace EShopOnAbp.CustomerService;

public class CustomerServiceBlazorAutoMapperProfile : Profile
{
    public CustomerServiceBlazorAutoMapperProfile()
    {
  
        CreateMap<CustomerPagedAndSortedResultRequestDto, Customer>()
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
        .ForMember(model => model.Gender, option => option.Ignore())
        .ForMember(model => model.Address, option => option.Ignore())
        .ForMember(model => model.Phone, option => option.Ignore())
         .ForMember(model => model.Id, option => option.Ignore());


    }
}
