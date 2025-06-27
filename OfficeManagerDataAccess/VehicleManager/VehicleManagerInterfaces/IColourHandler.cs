namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerInterfaces;

public interface IColourHandler
{
    Task<ColourModel> GetColourByIdAsync(int colourId);

    Task<List<ColourModel>> GetAllColoursAsync();

    Task CreateColourAsync(ColourModel colour);

    Task UpdateColourAsync(ColourModel colour);

    Task DeleteColourAsync(int colourId);
}
