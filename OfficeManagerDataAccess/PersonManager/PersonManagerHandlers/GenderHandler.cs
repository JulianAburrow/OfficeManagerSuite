
namespace OfficeManagerDataAccess.PersonManager.PersonManagerHandlers;

public class GenderHandler(PersonManagerDbContext context) : IGenderHandler
{
    private readonly PersonManagerDbContext _context = context;

    public async Task CreateGenderAsync(GenderModel genderModel)
    {
        _context.Genders.Add(genderModel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGenderAsync(int genderId)
    {
        var genderToDelete = await _context.Genders.FindAsync(genderId)
            ?? throw new ArgumentException(nameof(genderId), "Gender not found");

        _context.Genders.Remove(genderToDelete);
        await _context.SaveChangesAsync();
    }

    public Task<GenderModel> GetGenderByIdAsync(int genderId) =>
        _context.Genders
            .Include(g => g.Persons)
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.GenderId == genderId);

    public async Task<List<GenderModel>> GetAllGendersAsync() =>
        await _context.Genders
            .Include(g => g.Persons)
            .AsNoTracking()
            .OrderBy(g => g.GenderName)
            .ToListAsync();

    public async Task UpdateGenderAsync(GenderModel genderModel)
    {
        var genderToUpdate = await _context.Genders.FindAsync(genderModel.GenderId)
            ?? throw new ArgumentNullException(nameof(genderModel.GenderId), "Gender not found");

        genderToUpdate.GenderName = genderModel.GenderName;
        await _context.SaveChangesAsync();
    }
}
