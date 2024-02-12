using AutoMapper;
using SupplierManagement.Domain.Models;
using SupplierManagement.Resources;

namespace SupplierManagement.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Supplier, SupplierResource>();
    }
}