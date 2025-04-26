namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class EmergencyContactHandler(PersonManagerDbContext context) : IEmergencyContactHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreateEmergencyContactAsync(EmergencyContactModel emergencyContact)
    {
        _context.EmergencyContacts.Add(emergencyContact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmergencyContactAsync(int emergencyContactId)
    {
        var emergencyContactToDelete = await _context.EmergencyContacts.FindAsync(emergencyContactId)
            ?? throw new ArgumentNullException(nameof(emergencyContactId), "Emergency contact not found");
        
        _context.EmergencyContacts.Remove(emergencyContactToDelete);
        await _context.SaveChangesAsync();
    }

    public Task<EmergencyContactModel> GetEmergencyContactAsync(int emergencyContactId) =>
        _context.EmergencyContacts
            .Include(e => e.Person)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmergencyContactId == emergencyContactId);

    public Task<List<EmergencyContactModel>> GetEmergencyContactsAsync() =>
        _context.EmergencyContacts
            .Include(e => e.Person)
            .AsNoTracking()
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync();

    public Task<List<EmergencyContactModel>> GetEmergencyContactsByPersonIdAsync(int personId) =>
        _context.EmergencyContacts
            .Include(e => e.Person)
            .AsNoTracking()
            .Where(e => e.PersonId == personId)
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync();

    public async Task UpdateEmergencyContactAsync(EmergencyContactModel emergencyContact)
    {
        var emergencyContactToUpdate = await _context.EmergencyContacts.FindAsync(emergencyContact.EmergencyContactId)
            ?? throw new ArgumentNullException(nameof(emergencyContact.EmergencyContactId), "Emergency contact not found");

        emergencyContactToUpdate.FirstName = emergencyContact.FirstName;
        emergencyContactToUpdate.LastName = emergencyContact.LastName;
        emergencyContactToUpdate.PhoneNumber = emergencyContact.PhoneNumber;
        emergencyContactToUpdate.Relationship = emergencyContact.Relationship;

        await _context.SaveChangesAsync();
    }
}
