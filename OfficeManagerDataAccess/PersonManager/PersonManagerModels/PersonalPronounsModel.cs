namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class PersonalPronounsModel
{
    public int PersonalPronounsId { get; set; }

    public string PronounNames { get; set; } = default!;

    public ICollection<PersonModel> Persons { get; set; } = [];
}
