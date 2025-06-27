namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerInterfaces;

public interface IModelHandler
{
    Task<ModelModel> GetModelByIdAsync(int modelId);

    Task<List<ModelModel>> GetAllModelsAsync();

    Task CreateModelAsync(ModelModel model);

    Task UpdateModelAsync(ModelModel model);

    Task DeleteModelAsync(int modelId);
}
