namespace OfficeManagerUI.Models.PersonManagerModels;

public class EmergencyContactDisplayModel
{
    [Range(1, int.MaxValue, ErrorMessage = "{0} is required.")]
    [Display(Name = "Person")]
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
    public string PhoneNumber { get; set; } = default!;

    [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string? Relationship { get; set; } = default!;

    public string StaffMemberName { get; set; } = default!;
}
