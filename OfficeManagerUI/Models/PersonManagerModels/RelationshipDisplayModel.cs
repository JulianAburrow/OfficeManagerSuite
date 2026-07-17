namespace OfficeManagerUI.Models.PersonManagerModels;

public class RelationshipDisplayModel
{
    public int RelationshipId { get; set; }

    [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Relationship")]
    public string RelationshipName { get; set; } = string.Empty;

    public int PersonCount { get; set; }


}
