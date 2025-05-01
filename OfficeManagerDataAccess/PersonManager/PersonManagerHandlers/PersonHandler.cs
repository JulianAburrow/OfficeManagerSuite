namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class PersonHandler(PersonManagerDbContext context) : IPersonHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreatePersonAsync(PersonModel personModel)
    {
        _context.People.Add(personModel);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePersonAsync(int personId)
    {
        var personToDelete = await _context.People.FindAsync(personId)
            ?? throw new ArgumentException(nameof(personId), "Person not found");

        _context.People.Remove(personToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PersonModel>> GetAllPeopleAsync() =>
        await _context.People
            .Include(p => p.Addresses)
            .Include(p => p.EmploymentStatus)
            .Include(p => p.PersonalPronouns)
            .Include(p => p.Gender)
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<PersonModel>> GetAllPeopleForEmergencyContactAsync() =>
        await _context.People
            .AsNoTracking()
            .OrderBy(p => p.LastName)
            .ToListAsync();

    public async Task<PersonModel> GetPersonByIdAsync(int personId) =>
        await _context.People
            .Include(p => p.Addresses)
                .ThenInclude(a => a.AddressType)
            .Include(p => p.EmergencyContacts)
            .Include(p => p.EmploymentStatus)
            .Include(p => p.PersonalPronouns)
            .Include(p => p.Gender)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PersonId == personId);

    public async Task UpdatePersonAsync(PersonModel personModel)
    {
        var personToUpdate = _context.People.Find(personModel.PersonId)
            ?? throw new ArgumentException(nameof(personModel), "Person not found");

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

        await _context.SaveChangesAsync();
    }
}
