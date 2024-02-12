using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplierManagement.Domain.Models;
using SupplierManagement.Domain.Services;
using SupplierManagement.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplierManagement.Controllers;

[ApiController]
[Produces("application/json")]
[Route("/api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;

    public SupplierController(ISupplierService supplierService, IMapper mapper)
    {
        _supplierService = supplierService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all suppliers",
        Description = "Return all the supplier order by last date of edition",
        OperationId = "GetSuppliers")]
    [ProducesResponseType(typeof(IEnumerable<SupplierResource>), 200)]
    public async Task<IEnumerable<SupplierResource>> GetAllAsync()
    {
        var suppliers = await _supplierService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(suppliers);
        return resources;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create new supplier",
        Description = "Create new supplier",
        OperationId = "CreateSupplier")]
    public async Task<IActionResult> CreateSupplier([FromBody] SaveSupplierResource resource)
    {
        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
        var result = await _supplierService.SaveAsync(supplier);
        if (!result.Succes)
            return BadRequest(result.Message);
        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);
        return Ok(supplierResource);
    }

    [HttpDelete("{taxIdentification}")]
    [SwaggerOperation(
        Summary = "Delete a supplier",
        Description = "Delete an existing supplier",
        OperationId = "DeleteSupplier")]
    public async Task<IActionResult> DeleteAsync(string taxIdentification)
    {
        var result = await _supplierService.DeleteAsync(taxIdentification);
        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);
        return Ok(supplierResource);
    }

    [HttpPut("{taxIdentification}")]
    [SwaggerOperation(
        Summary = "Update a supplier",
        Description = "Update an existing supplier",
        OperationId = "UpdateSupplier")]
    public async Task<IActionResult> PutAsync(string taxIdentification, [FromBody] SaveSupplierResource resource)
    {
        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
        var result = await _supplierService.UpdateAsync(taxIdentification, supplier);
        return Ok(result);
    }
}