namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerHandlers;

public class ManufacturerHandler(VehicleManagerDbContext context) : IManufacturerHandler
{
    private readonly VehicleManagerDbContext _context = context;

    public async Task CreateManufacturerAsync(ManufacturerModel manufacturer)
    {
        _context.Manufacturers.Add(manufacturer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteManufacturerAsync(int manufacturerId)
    {
        var manufacturerToDelete = _context.Manufacturers.Find(manufacturerId)
            ?? throw new ArgumentNullException(nameof(manufacturerId), "Manufacturer not found");
        
        _context.Manufacturers.Remove(manufacturerToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<ManufacturerModel> GetManufacturerByIdAsync(int manufacturerId) =>
        await _context.Manufacturers
            .Include(m => m.Vehicles)
            .Include(m => m.Models)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId)
            ?? throw new ArgumentNullException(nameof(manufacturerId), "Manufacturer not found");

    public async Task<List<ManufacturerModel>> GetAllManufacturersAsync() =>
        await _context.Manufacturers
            .Include(m => m.Vehicles)
            .Include(m => m.Models)
            .AsNoTracking()
            .OrderBy(m => m.ManufacturerName)
            .ToListAsync();

    public async Task UpdateManufacturerAsync(ManufacturerModel manufacturer)
    {
        var manufacturerToUpdate = _context.Manufacturers.Find(manufacturer.ManufacturerId)
            ?? throw new ArgumentNullException(nameof(manufacturer.ManufacturerId), "Manufacturer not found");

        manufacturerToUpdate.ManufacturerName = manufacturer.ManufacturerName;

        await _context.SaveChangesAsync();
    }
}
