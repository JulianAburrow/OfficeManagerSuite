namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerHandlers;

public class ModelHandler(VehicleManagerDbContext context) : IModelHandler
{
    private readonly VehicleManagerDbContext _context = context;

    public async Task CreateModelAsync(ModelModel model)
    {
        _context.Models.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteModelAsync(int modelId)
    {
        var modelToDelete = _context.Models.Find(modelId)
            ?? throw new ArgumentNullException(nameof(modelId), "Model not found");

        _context.Models.Remove(modelToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<ModelModel> GetModelByIdAsync(int modelId) =>
        await _context.Models
            .Include(m => m.Manufacturer)
            .Include(m => m.Vehicles)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ModelId == modelId)
            ?? throw new ArgumentNullException(nameof(modelId), "Model not found");


    public async Task<List<ModelModel>> GetAllModelsAsync() =>
        await _context.Models
            .Include(m => m.Manufacturer)
            .Include(m => m.Vehicles)
            .AsNoTracking()
            .OrderBy(m => m.ModelName)
            .ToListAsync();

    public async Task UpdateModelAsync(ModelModel model)
    {
        var modelToUpdate = _context.Models.Find(model.ModelId)
            ?? throw new ArgumentNullException(nameof(model.ModelId), "Model not found");

        modelToUpdate.ModelName = model.ModelName;
        modelToUpdate.ManufacturerId = model.ManufacturerId;

        await _context.SaveChangesAsync();

    }
}
