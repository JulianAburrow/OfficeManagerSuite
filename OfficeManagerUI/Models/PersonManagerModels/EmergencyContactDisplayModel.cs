namespace OfficeManagerUI.Models.PersonManagerModels;

public class EmergencyContactDisplayModel
{
    public int EmergencyContactId { get; set; }

    public int PersonId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = default!;

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters.")]
    [Display(Name = "Phone Number")]
    public string Phone { get; set; } = default!;

    [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string? Relationship { get; set; } = default!;

    public PersonModel Person { get; set; } = null!;
}
