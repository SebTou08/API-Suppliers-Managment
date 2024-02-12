using SupplierManagement.Domain.Persistence.Context;

namespace SupplierManagement.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext Context;
    
    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }
    
}