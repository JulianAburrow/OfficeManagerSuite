namespace OfficeManagerUI.Models.VehicleManagerModels;

public class ModelDisplayModel
{
    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Model Name")]
    public string ModelName { get; set; } = default!;

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    public int ManufacturerId { get; set; }
}
