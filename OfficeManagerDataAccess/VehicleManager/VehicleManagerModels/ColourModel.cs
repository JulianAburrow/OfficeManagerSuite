namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerModels;

public class ColourModel
{
    public int ColourId { get; set; }

    public string ColourName { get; set; } = default!;

    public ICollection<VehicleModel> Vehicles { get; set; } = null!;
}
