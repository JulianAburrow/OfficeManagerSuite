namespace OfficeManagerUI.Models.PersonManagerModels;

public class AddressTypeDisplayModel
{
    public int AddressTypeId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters.")]
    [Display(Name = "Address Type")]
    public string TypeName { get; set; } = default!;
}
