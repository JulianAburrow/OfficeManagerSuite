namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IPersonalPronounsHandler
{
    Task<PersonalPronounsModel> GetPersonalPronounAsync(int personalPronounsId);

    Task<List<PersonalPronounsModel>> GetPersonalPronounsAsync();

    Task CreatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel);

    Task UpdatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel);

    Task DeletePersonalPronounsAsync(int personalPronounsId);
}