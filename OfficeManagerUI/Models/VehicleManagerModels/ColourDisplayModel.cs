namespace OfficeManagerUI.Models.VehicleManagerModels;

public class ColourDisplayModel
{
    public int ColourId { get; set; }

    [Required(ErrorMessage = "{0}} is required.")]
    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Colour Name")]
    public string ColourName { get; set; } = string.Empty;
}
