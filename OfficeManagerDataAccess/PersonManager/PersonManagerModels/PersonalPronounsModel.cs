namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class PersonalPronounsModel
{
    public int PersonalPronounsId { get; set; }

    public string PronounNames { get; set; } = null!;

    public ICollection<PersonModel> Persons { get; set; } = [];
}
