namespace OfficeManagerUI.Models.VehicleManagerModels;

public class ColourDisplayModel
{
    public int ColourId { get; set; }

    [Required(ErrorMessage = "{0}} is required.")]
    [Display(Name = "Colour Name")]
    public string ColourName { get; set; } = default!;
}
