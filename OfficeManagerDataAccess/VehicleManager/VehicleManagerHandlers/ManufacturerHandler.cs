namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerHandlers;

public class ManufacturerHandler(IDbContextFactory<VehicleManagerDbContext> factory) : IManufacturerHandler
{
    public async Task CreateManufacturerAsync(ManufacturerModel manufacturer)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Manufacturers.Add(manufacturer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteManufacturerAsync(int manufacturerId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var manufacturerToDelete = await context.Manufacturers.FindAsync(manufacturerId);

        if (manufacturerToDelete is null)
        {
            return;
        }
        
        context.Manufacturers.Remove(manufacturerToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<ManufacturerModel> GetManufacturerByIdAsync(int manufacturerId)
    {
        await using var context = await factory.CreateDbContextAsync();

        var manufacturer = await context.Manufacturers
            .Include(m => m.Vehicles)
            .Include(m => m.Models)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);

        return manufacturer ?? new ManufacturerModel();
    }        

    public async Task<List<ManufacturerModel>> GetAllManufacturersAsync()
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Manufacturers
            .Include(m => m.Vehicles)
            .Include(m => m.Models)
            .AsNoTracking()
            .OrderBy(m => m.ManufacturerName)
            .ToListAsync();
    }
        

    public async Task UpdateManufacturerAsync(ManufacturerModel manufacturer)
    {
        await using var context = await factory.CreateDbContextAsync();
        var manufacturerToUpdate = await context.Manufacturers.FindAsync(manufacturer.ManufacturerId);

        if (manufacturerToUpdate is null)
        {
            return;
        }

        manufacturerToUpdate.ManufacturerName = manufacturer.ManufacturerName;

        await context.SaveChangesAsync();
    }
}
