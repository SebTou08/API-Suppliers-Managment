using SupplierManagement.Domain.Persistence.Context;
using SupplierManagement.Domain.Persistence.Repositories;

namespace SupplierManagement.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{

    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}