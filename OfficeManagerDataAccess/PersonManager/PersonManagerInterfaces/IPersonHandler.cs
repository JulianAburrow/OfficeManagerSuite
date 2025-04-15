namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IPersonHandler
{
    Task<List<PersonModel>> GetPeopleForEmergencyContactAsync();
}
