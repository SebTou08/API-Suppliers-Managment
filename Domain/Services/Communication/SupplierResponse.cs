using SupplierManagement.Domain.Models;

namespace SupplierManagement.Domain.Services.Communication;

public class SupplierResponse : BaseResponse<Supplier>
{
    
    public SupplierResponse(Supplier resource) : base(resource){}
    
    public SupplierResponse(string message) : base(message){}
    
}