namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerInterfaces;

public interface IManufacturerHandler
{
    Task<ManufacturerModel> GetManufacturerByIdAsync(int manufacturerId);

    Task<List<ManufacturerModel>> GetAllManufacturersAsync();

    Task CreateManufacturerAsync(ManufacturerModel manufacturer);

    Task UpdateManufacturerAsync(ManufacturerModel manufacturer);

    Task DeleteManufacturerAsync(int manufacturerId);
}
