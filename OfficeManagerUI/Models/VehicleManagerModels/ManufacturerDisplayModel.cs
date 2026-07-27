namespace OfficeManagerUI.Models.VehicleManagerModels;

public class ManufacturerDisplayModel
{
    public int ManufacturerId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Manufacturer Name")]
    public string ManufacturerName { get; set; } = string.Empty;
}
