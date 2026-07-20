namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class EmergencyContactHandler(IDbContextFactory<PersonManagerDbContext> factory) : IEmergencyContactHandler
{
    public async Task CreateEmergencyContactAsync(EmergencyContactModel emergencyContact)
    {
        await using var context = factory.CreateDbContext();
        context.EmergencyContacts.Add(emergencyContact);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEmergencyContactAsync(int emergencyContactId)
    {
        await using var context = factory.CreateDbContext();
        var emergencyContactToDelete = await context.EmergencyContacts.FindAsync(emergencyContactId);

        if (emergencyContactToDelete is null)
        {
            return;
        }
        
        context.EmergencyContacts.Remove(emergencyContactToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<EmergencyContactModel> GetEmergencyContactByIdAsync(int emergencyContactId)
    {
        await using var context = factory.CreateDbContext();
        var emergencyContact =  await context.EmergencyContacts
            .Include(e => e.Person)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmergencyContactId == emergencyContactId);

        return emergencyContact ?? new EmergencyContactModel();
    }
       

    public async Task<List<EmergencyContactModel>> GetAllEmergencyContactsAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.EmergencyContacts
            .Include(e => e.Person)
            .AsNoTracking()
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync();
    }
        

    public async Task<List<EmergencyContactModel>> GetAllEmergencyContactsByPersonIdAsync(int personId)
    {
        await using var context = factory.CreateDbContext();
        return await context.EmergencyContacts
            .Include(e => e.Person)
            .AsNoTracking()
            .Where(e => e.PersonId == personId)
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync();
    }
        

    public async Task UpdateEmergencyContactAsync(EmergencyContactModel emergencyContact)
    {
        await using var context = factory.CreateDbContext();
        var emergencyContactToUpdate = await context.EmergencyContacts.FindAsync(emergencyContact.EmergencyContactId);

        if (emergencyContactToUpdate is null)
        {
            return;
        }

        emergencyContactToUpdate.FirstName = emergencyContact.FirstName;
        emergencyContactToUpdate.LastName = emergencyContact.LastName;
        emergencyContactToUpdate.PhoneNumber = emergencyContact.PhoneNumber;
        emergencyContactToUpdate.Relationship = emergencyContact.Relationship;

        await context.SaveChangesAsync();
    }
}
