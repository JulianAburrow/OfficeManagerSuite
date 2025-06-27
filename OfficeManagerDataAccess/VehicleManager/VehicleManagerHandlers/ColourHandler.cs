    namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerHandlers;

public class ColourHandler(VehicleManagerDbContext context) : IColourHandler
{
    private readonly VehicleManagerDbContext _context = context;

    public async Task CreateColourAsync(ColourModel colour)
    {
        _context.Colours.Add(colour);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteColourAsync(int colourId)
    {
        var colourToDelete = _context.Colours.Find(colourId)
            ?? throw new ArgumentNullException(nameof(colourId), "Colour not found");

        _context.Colours.Remove(colourToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<ColourModel> GetColourByIdAsync(int colourId) =>
        await _context.Colours
            .Include(c => c.Vehicles)
            .FirstOrDefaultAsync(c => c.ColourId == colourId) 
            ?? throw new ArgumentNullException(nameof(colourId), "Colour not found");

    public Task<List<ColourModel>> GetAllColoursAsync() =>
        _context.Colours
            .Include(c => c.Vehicles)
            .OrderBy(c => c.ColourName)
            .ToListAsync();

    public async Task UpdateColourAsync(ColourModel colour)
    {
        var colourToUpdate = _context.Colours.Find(colour.ColourId)
            ?? throw new ArgumentNullException(nameof(colour.ColourId), "Colour not found");

        colourToUpdate.ColourName = colour.ColourName;

        await _context.SaveChangesAsync();
    }
}
