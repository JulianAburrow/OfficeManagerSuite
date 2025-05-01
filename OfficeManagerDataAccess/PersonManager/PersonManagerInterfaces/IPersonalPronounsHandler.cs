namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IPersonalPronounsHandler
{
    Task<PersonalPronounsModel> GetPersonalPronounsByIdAsync(int personalPronounsId);

    Task<List<PersonalPronounsModel>> GetAllPersonalPronounsAsync();

    Task CreatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel);

    Task UpdatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel);

    Task DeletePersonalPronounsAsync(int personalPronounsId);
}