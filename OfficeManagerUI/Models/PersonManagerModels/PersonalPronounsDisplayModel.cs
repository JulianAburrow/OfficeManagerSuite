namespace OfficeManagerUI.Models.PersonManagerModels;

public class PersonalPronounsDisplayModel
{
    public int PersonalPronounsId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters.")]
    [Display(Name = "Pronoun Names")]
    public string PronounNames { get; set; } = default!;
}
