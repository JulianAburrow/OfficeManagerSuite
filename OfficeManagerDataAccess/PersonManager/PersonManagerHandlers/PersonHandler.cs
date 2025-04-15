namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class PersonHandler(PersonManagerDbContext context) : IPersonHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task<List<PersonModel>> GetPeopleForEmergencyContactAsync() =>
        await _context.People
            .AsNoTracking()
            .OrderBy(p => p.LastName)
            .ToListAsync();
}
