using AutoMapper;
using SupplierManagement.Domain.Models;
using SupplierManagement.Resources;

namespace SupplierManagement.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveSupplierResource, Supplier>();
    }
}