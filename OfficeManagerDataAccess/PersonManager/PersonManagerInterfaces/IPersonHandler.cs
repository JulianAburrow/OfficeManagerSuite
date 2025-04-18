namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IPersonHandler
{
    Task<List<PersonModel>> GetPeopleForEmergencyContactAsync();

    Task<List<PersonModel>> GetPeopleAsync();

    Task<PersonModel> GetPersonAsync(int personId);

    Task CreatePersonAsync(PersonModel personModel);

    Task UpdatePersonAsync(PersonModel personModel);

    Task DeletePersonAsync(int personId);
}
