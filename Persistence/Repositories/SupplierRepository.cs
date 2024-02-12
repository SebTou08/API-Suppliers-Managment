using Microsoft.EntityFrameworkCore;
using SupplierManagement.Domain.Models;
using System.Linq;
using SupplierManagement.Domain.Persistence.Context;
using SupplierManagement.Domain.Persistence.Repositories;

namespace SupplierManagement.Persistence.Repositories;

public class SupplierRepository : BaseRepository, ISupplierRepository
{
    public SupplierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await Context.Suppliers
            .OrderByDescending(s => s.LastEditionDate)
            .ToListAsync();
    }

    public async Task AddAsync(Supplier supplier)
    {
        await Context.Suppliers.AddAsync(supplier);
        Context.SaveChanges();
    }

    public async Task<Supplier?> FindByTaxIdentification(string taxIdentification)
    {
        return await Context.Suppliers.Where(s => s.TaxIdentification == taxIdentification)
            .FirstOrDefaultAsync();
    }

    public void Remove(Supplier supplier)
    {
        Context.Remove(supplier);
        Context.SaveChanges();
    }

    public void Update(Supplier supplier)
    {
        Context.Suppliers.Remove(supplier);
        Context.SaveChanges();
    }
}