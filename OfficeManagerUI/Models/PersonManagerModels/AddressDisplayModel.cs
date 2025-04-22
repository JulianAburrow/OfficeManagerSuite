namespace OfficeManagerUI.Models.PersonManagerModels;

public class AddressDisplayModel
{
    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    [Display(Name = "Person")]
    public int PersonId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Address Line 1")]
    public string AddressLine1 { get; set; } = default!;

    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Address Line 2")]
    public string AddressLine2 { get; set; } = null!;

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    public string City { get; set; } = default!;

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters")]
    public string Postcode { get; set; } = default!;

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    [Display(Name = "Address Type")]
    public int AddressTypeId { get; set; }
}