namespace OfficeManagerDataAccess.PersonManager.PersonManagerInterfaces;

public interface IEmergencyContactHandler
{
    Task CreateEmergencyContactAsync(EmergencyContactModel emergencyContact);

    Task<EmergencyContactModel> GetEmergencyContactByIdAsync(int emergencyContactId);

    Task<List<EmergencyContactModel>> GetEmergencyContactsByPersonIdAsync(int personId);

    Task<List<EmergencyContactModel>> GetEmergencyContactsAsync();

    Task UpdateEmergencyContactAsync(EmergencyContactModel emergencyContact);

    Task DeleteEmergencyContactAsync(int emergencyContactId);
}
