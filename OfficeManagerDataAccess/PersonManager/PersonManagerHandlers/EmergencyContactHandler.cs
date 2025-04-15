namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class EmergencyContactHandler(PersonManagerDbContext context) : IEmergencyContactHandler
{
    private readonly PersonManagerDbContext _context = context;

    public Task CreateEmergencyContactAsync(EmergencyContactModel emergencyContact)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmergencyContactAsync(int emergencyContactId)
    {
        throw new NotImplementedException();
    }

    public Task<EmergencyContactModel> GetEmergencyContactByIdAsync(int emergencyContactId)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmergencyContactModel>> GetEmergencyContactsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<EmergencyContactModel>> GetEmergencyContactsByPersonIdAsync(int personId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmergencyContactAsync(EmergencyContactModel emergencyContact)
    {
        throw new NotImplementedException();
    }
}
