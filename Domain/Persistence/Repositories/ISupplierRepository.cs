using SupplierManagement.Domain.Models;

namespace SupplierManagement.Domain.Persistence.Repositories;

public interface ISupplierRepository
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task AddAsync(Supplier supplier);
    Task<Supplier?> FindByTaxIdentification(string taxIdentification);
    void Remove(Supplier supplier);
    void Update(Supplier supplier);

}