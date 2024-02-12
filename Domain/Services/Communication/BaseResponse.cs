namespace SupplierManagement.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    public T Resource { get; set; }
    public string Message { get; protected set; }
    public bool Succes { get; set; }


    protected BaseResponse(T resource)
    {
        Resource = resource;
        Succes = true;
        Message = string.Empty;
    }

    protected BaseResponse(string message)
    {
        Succes = false;
        Message = message;
    }
}