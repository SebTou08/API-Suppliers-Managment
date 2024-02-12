using System.ComponentModel.DataAnnotations;

namespace SupplierManagement.Resources;

public class SaveSupplierResource
{
    [Required(ErrorMessage = "Business Name is required")]
    public string BusinessName { get; set; }

    [Required(ErrorMessage = "Tradename is required")]
    public string Tradename { get; set; }

    [Required(ErrorMessage = "Tax Identification is required")]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = "Tax Identification must be 11 digits")]
    public string TaxIdentification { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number format")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Website is required")]
    [Url(ErrorMessage = "Invalid URL format")]
    public string Website { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Annual Billing is required")]
    [DataType(DataType.Currency, ErrorMessage = "Invalid Annual Billing format")]
    public decimal AnnualBilling { get; set; }
}