
namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class GenderHandler(IDbContextFactory<PersonManagerDbContext> factory) : IGenderHandler
{
    public async Task CreateGenderAsync(GenderModel genderModel)
    {
        await using var context = factory.CreateDbContext();
        context.Genders.Add(genderModel);
        await context.SaveChangesAsync();
    }

    public async Task DeleteGenderAsync(int genderId)
    {
        await using var context = factory.CreateDbContext();
        var genderToDelete = await context.Genders.FindAsync(genderId);

        if (genderToDelete is null)
        {
            return;
        }

        context.Genders.Remove(genderToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<GenderModel> GetGenderByIdAsync(int genderId)
    {
        await using var context = factory.CreateDbContext();
        var gender = await context.Genders
            .Include(g => g.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.GenderId == genderId);

        return gender ?? new GenderModel();
    }
        

    public async Task<List<GenderModel>> GetAllGendersAsync()
    {
        await using var context = factory.CreateDbContext();
        return await context.Genders
            .Include(g => g.Persons)
            .AsNoTracking()
            .OrderBy(g => g.GenderName)
            .ToListAsync();
    }
        

    public async Task UpdateGenderAsync(GenderModel genderModel)
    {
        await using var context = factory.CreateDbContext();
        var genderToUpdate = await context.Genders.FindAsync(genderModel.GenderId);

        if (genderToUpdate is null)
        {
            return;
        }

        genderToUpdate.GenderName = genderModel.GenderName;
        await context.SaveChangesAsync();
    }
}
