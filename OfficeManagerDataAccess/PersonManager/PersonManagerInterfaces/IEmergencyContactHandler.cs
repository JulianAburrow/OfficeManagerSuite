namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IEmergencyContactHandler
{
    Task CreateEmergencyContactAsync(EmergencyContactModel emergencyContact);

    Task<EmergencyContactModel> GetEmergencyContactByIdAsync(int emergencyContactId);

    Task<List<EmergencyContactModel>> GetAllEmergencyContactsByPersonIdAsync(int personId);

    Task<List<EmergencyContactModel>> GetAllEmergencyContactsAsync();

    Task UpdateEmergencyContactAsync(EmergencyContactModel emergencyContact);

    Task DeleteEmergencyContactAsync(int emergencyContactId);

    Task<List<string>> GetAllRelationshipsAsync();
}
