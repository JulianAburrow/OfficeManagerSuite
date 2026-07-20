
namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class PersonalPronounsHandler(IDbContextFactory<PersonManagerDbContext> factory) : IPersonalPronounsHandler
{
    public async Task CreatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel)
    {
        await using var context = factory.CreateDbContext();
        context.PersonalPronouns.Add(personalPronounsModel);
        await context.SaveChangesAsync();
    }

    public async Task DeletePersonalPronounsAsync(int personalPronounsId)
    {
        await using var context = factory.CreateDbContext();
        var personalPronounsToDelete = await context.PersonalPronouns.FindAsync(personalPronounsId);
            
        if (personalPronounsToDelete is null)
        {
            return;
        }

        context.PersonalPronouns.Remove(personalPronounsToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<PersonalPronounsModel> GetPersonalPronounsByIdAsync(int personalPronounsId)
    {
        await using var context = factory.CreateDbContext();
        var personalPronouns = await context.PersonalPronouns
            .Include(p => p.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PersonalPronounsId == personalPronounsId);

        return personalPronouns ?? new PersonalPronounsModel();
    }
        

    public async Task<List<PersonalPronounsModel>> GetAllPersonalPronounsAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.PersonalPronouns
            .Include(p => p.Persons)
            .AsNoTracking()
            .OrderBy(p => p.PronounNames)
            .ToListAsync();
    }
        

    public async Task UpdatePersonalPronounsAsync(PersonalPronounsModel personalPronounsModel)
    {
        await using var context = factory.CreateDbContext();
        var personalPronounsToUpdate = await context.PersonalPronouns.FindAsync(personalPronounsModel.PersonalPronounsId);

        if (personalPronounsToUpdate is null)
        {
            return;
        }

        personalPronounsToUpdate.PronounNames = personalPronounsModel.PronounNames;

        await context.SaveChangesAsync();
    }
}
