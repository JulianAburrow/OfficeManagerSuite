namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerModels;

public class ManufacturerModel
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = default!;

    public ICollection<VehicleModel> Vehicles { get; set; } = null!;

    public ICollection<ModelModel> Models { get; set; } = null!;
}
