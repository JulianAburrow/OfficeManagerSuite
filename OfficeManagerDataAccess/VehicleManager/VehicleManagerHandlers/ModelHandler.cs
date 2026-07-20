namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerHandlers;

public class ModelHandler(IDbContextFactory<VehicleManagerDbContext> factory) : IModelHandler
{
    public async Task CreateModelAsync(ModelModel model)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Models.Add(model);
        await context.SaveChangesAsync();
    }

    public async Task DeleteModelAsync(int modelId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var modelToDelete = await context.Models.FindAsync(modelId);

        if (modelToDelete is null)
        {
            return;
        }

        context.Models.Remove(modelToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<ModelModel> GetModelByIdAsync(int modelId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var model = await context.Models
            .Include(m => m.Manufacturer)
            .Include(m => m.Vehicles)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ModelId == modelId);

        return model ?? new ModelModel();
    }

    public async Task<List<ModelModel>> GetAllModelsAsync()
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Models
            .Include(m => m.Manufacturer)
            .Include(m => m.Vehicles)
            .AsNoTracking()
            .OrderBy(m => m.ModelName)
            .ToListAsync();
    }
        

    public async Task UpdateModelAsync(ModelModel model)
    {
        await using var context = await factory.CreateDbContextAsync();
        var modelToUpdate = await context.Models.FindAsync(model.ModelId);

        if (modelToUpdate is null)
        {
            return;
        }

        modelToUpdate.ModelName = model.ModelName;
        modelToUpdate.ManufacturerId = model.ManufacturerId;

        await context.SaveChangesAsync();

    }
}
