    namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerHandlers;

public class ColourHandler(IDbContextFactory<VehicleManagerDbContext> factory) : IColourHandler
{
    public async Task CreateColourAsync(ColourModel colour)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Colours.Add(colour);
        await context.SaveChangesAsync();
    }

    public async Task DeleteColourAsync(int colourId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var colourToDelete = await context.Colours.FindAsync(colourId);

        if (colourToDelete is null)
        {
            return;
        }

        context.Colours.Remove(colourToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<ColourModel> GetColourByIdAsync(int colourId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var colour = await context.Colours
            .Include(c => c.Vehicles)
            .FirstOrDefaultAsync(c => c.ColourId == colourId);

        return colour ?? new ColourModel();
    }
        

    public async Task<List<ColourModel>> GetAllColoursAsync()
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Colours
            .Include(c => c.Vehicles)
            .OrderBy(c => c.ColourName)
            .ToListAsync();
    }
        

    public async Task UpdateColourAsync(ColourModel colour)
    {
        await using var context = await factory.CreateDbContextAsync();
        var colourToUpdate = await context.Colours.FindAsync(colour.ColourId);

        if (colourToUpdate is null)
        {
            return;
        }

        colourToUpdate.ColourName = colour.ColourName;

        await context.SaveChangesAsync();
    }
}
