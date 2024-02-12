using SupplierManagement.Domain.Models;
using SupplierManagement.Domain.Persistence.Repositories;
using SupplierManagement.Domain.Services;
using SupplierManagement.Domain.Services.Communication;

namespace SupplierManagement.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
    }
    
    
    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _supplierRepository.ListAsync();
    }

    public async Task<SupplierResponse> GetByTaxIdentification(string taxIdentification)
    {
        var existingSupplier = await _supplierRepository.FindByTaxIdentification(taxIdentification);
        return existingSupplier == null ? new SupplierResponse("Supplier not found") : new SupplierResponse(existingSupplier);
    }

    public async Task<SupplierResponse> DeleteAsync(string taxIdentification)
    {
        var existingSupplier = await _supplierRepository.FindByTaxIdentification(taxIdentification);
        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");

        try
        {
            _supplierRepository.Remove(existingSupplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occured while removing supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> UpdateAsync(string taxIdentification, Supplier supplier)
    {
        var existingSupplier = await _supplierRepository.FindByTaxIdentification(taxIdentification);
        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");

        try
        {
            existingSupplier.Address = supplier.Address;
            existingSupplier.Country = supplier.Country;
            existingSupplier.AnnualBilling = supplier.AnnualBilling;
            existingSupplier.Email = supplier.Email;
            existingSupplier.Tradename = supplier.Tradename;
            existingSupplier.Website = supplier.Website;
            existingSupplier.PhoneNumber = supplier.PhoneNumber;
            existingSupplier.LastEditionDate = DateTime.Now;
            existingSupplier.BusinessName = supplier.BusinessName;
            
            
            
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(supplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occured while updating supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> SaveAsync(Supplier supplier)
    {
        var existingSupplier = await _supplierRepository.FindByTaxIdentification(supplier.TaxIdentification);
        if (existingSupplier != null)
            return new SupplierResponse(
                $"Supplier with Tax Identification ${supplier.TaxIdentification} already exists");
        try
        {
            supplier.LastEditionDate = DateTime.Now;
            await _supplierRepository.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(supplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occured while creating supplier: {e.Message}");
        }
    }
}