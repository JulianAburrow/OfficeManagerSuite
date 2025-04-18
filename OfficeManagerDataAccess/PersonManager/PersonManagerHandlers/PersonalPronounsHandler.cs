
namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class PersonalPronounsHandler(PersonManagerDbContext context) : IPersonalPronounsHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel)
    {
        _context.PersonalPronouns.Add(personalPronounsModel);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePersonalPronounsAsync(int personalPronounsId)
    {
        var personalPronounsToDelete = await _context.PersonalPronouns.FindAsync(personalPronounsId)
            ?? throw new ArgumentNullException(nameof(personalPronounsId), "Personal pronouns not found");

        _context.PersonalPronouns.Remove(personalPronounsToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<PersonalPronounsModel> GetPersonalPronounAsync(int personalPronounsId) =>
        await _context.PersonalPronouns
            .Include(p => p.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PersonalPronounsId == personalPronounsId);

    public async Task<List<PersonalPronounsModel>> GetPersonalPronounsAsync() =>
        await _context.PersonalPronouns
            .Include(p => p.Persons)
            .AsNoTracking()
            .OrderBy(p => p.PronounNames)
            .ToListAsync();

    public async Task UpdatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel)
    {
        var personalPronounsToUpdate = await _context.PersonalPronouns.FindAsync(personalPronounsModel.PersonalPronounsId)
            ?? throw new ArgumentNullException(nameof(personalPronounsModel.PersonalPronounsId), "Personal pronouns not found");

        personalPronounsToUpdate.PronounNames = personalPronounsModel.PronounNames;

        await _context.SaveChangesAsync();

    }
}
