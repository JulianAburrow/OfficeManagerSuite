namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class GenderModel
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = default!;

    public ICollection<PersonModel> Persons { get; set; } = [];
}
