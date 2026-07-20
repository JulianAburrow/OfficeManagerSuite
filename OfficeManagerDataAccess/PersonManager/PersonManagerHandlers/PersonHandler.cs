namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class PersonHandler(IDbContextFactory<PersonManagerDbContext> factory) : IPersonHandler
{
    public async Task CreatePersonAsync(PersonModel personModel)
    {
        await using var context = factory.CreateDbContext();
        context.People.Add(personModel);
        await context.SaveChangesAsync();
    }

    public async Task DeletePersonAsync(int personId)
    {
        await using var context = factory.CreateDbContext();
        var personToDelete = await context.People.FindAsync(personId);

        if (personToDelete is null)
        {
            return;
        }

        context.People.Remove(personToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<List<PersonModel>> GetAllPeopleAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.People
            .Include(p => p.Addresses)
            .Include(p => p.EmploymentStatus)
            .Include(p => p.PersonalPronouns)
            .AsNoTracking()
            .Include(p => p.Gender)
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ToListAsync();
    }       

    public async Task<List<PersonModel>> GetAllPeopleForEmergencyContactAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.People
            .AsNoTracking()
            .OrderBy(p => p.LastName)
            .ToListAsync();
    }
        

    public async Task<PersonModel> GetPersonByIdAsync(int personId)
    {
        await using var context = factory.CreateDbContext();
        var person = await context.People
            .Include(p => p.Addresses)
                .ThenInclude(a => a.AddressType)
            .Include(p => p.EmergencyContacts)
                .ThenInclude(e => e.Relationship)
            .Include(p => p.EmploymentStatus)
            .Include(p => p.PersonalPronouns)
            .Include(p => p.Gender)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PersonId == personId);

        return person ?? new PersonModel();
    }
    
    public async Task UpdatePersonAsync(PersonModel personModel)
    {
        await using var context = factory.CreateDbContext();
        var personToUpdate = await context.People.FindAsync(personModel.PersonId);

        if (personToUpdate is null)
        {
            return;
        }

        personToUpdate.FirstName = personModel.FirstName;
        personToUpdate.MiddleNames = personModel.MiddleNames;
        personToUpdate.LastName = personModel.LastName;
        personToUpdate.EmailAddress = personModel.EmailAddress;
        personToUpdate.PhoneNumber = personModel.PhoneNumber;
        personToUpdate.PersonalPronounsId = personModel.PersonalPronounsId;
        personToUpdate.GenderId = personModel.GenderId;
        personToUpdate.EmploymentStatusId = personModel.EmploymentStatusId;
        personToUpdate.Photo = personModel.Photo;
        personToUpdate.Pronunciation = personModel.Pronunciation;

        await context.SaveChangesAsync();
    }
}
