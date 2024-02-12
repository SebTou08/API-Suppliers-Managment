namespace SupplierManagement.Domain.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}