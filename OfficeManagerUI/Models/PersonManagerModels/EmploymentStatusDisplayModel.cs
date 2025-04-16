namespace OfficeManagerUI.Models.PersonManagerModels;

public class EmploymentStatusDisplayModel
{
    public int EmploymentStatusId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters.")]
    [Display(Name = "Status Name")]
    public string StatusName { get; set; } = null!;

    public ICollection<PersonModel> Persons { get; set; } = [];
}
