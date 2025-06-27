namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerModels;

public class ModelModel
{
    public int ModelId { get; set; }

    public string ModelName { get; set; } = default!;

    public int ManufacturerId { get; set; }

    public ManufacturerModel Manufacturer { get; set; } = null!;

    public ICollection<VehicleModel> Vehicles { get; set; } = null!;
}
