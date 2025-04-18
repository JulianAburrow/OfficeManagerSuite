namespace OfficeManagerUI.Models.PersonManagerModels;

public class GenderDisplayModel
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = default!;

    public ICollection<PersonModel> Persons { get; set; } = [];
}
