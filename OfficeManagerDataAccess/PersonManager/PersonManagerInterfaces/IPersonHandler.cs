namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IPersonHandler
{
    Task<List<PersonModel>> GetAllPeopleForEmergencyContactAsync();

    Task<List<PersonModel>> GetAllPeopleAsync();

    Task<PersonModel> GetPersonByIdAsync(int personId);

    Task CreatePersonAsync(PersonModel personModel);

    Task UpdatePersonAsync(PersonModel personModel);

    Task DeletePersonAsync(int personId);
}
