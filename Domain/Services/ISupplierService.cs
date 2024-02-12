using SupplierManagement.Domain.Models;
using SupplierManagement.Domain.Services.Communication;

namespace SupplierManagement.Domain.Services;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task<SupplierResponse> GetByTaxIdentification(string taxIdentification);
    Task<SupplierResponse> DeleteAsync(string taxIdentification);
    Task<SupplierResponse> UpdateAsync(string taxIdentification, Supplier supplier);
    Task<SupplierResponse> SaveAsync(Supplier supplier);
}