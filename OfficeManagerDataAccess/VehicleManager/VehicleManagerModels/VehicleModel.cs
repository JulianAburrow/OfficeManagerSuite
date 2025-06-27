namespace OfficeManagerDataAccess.VehicleManager.VehicleManagerModels;

public class VehicleModel
{
    public int VehicleId { get; set; }

    public int ManufacturerId { get; set; }

    public int ModelId { get; set; }

    public string RegistrationNumber { get; set; } = default!;

    public int ColourId { get; set; }

    public int YearOfManufacture { get; set; }

    public ManufacturerModel Manufacturer { get; set; } = null!;

    public ColourModel Colour { get; set; } = null!;

    public ModelModel Model { get; set; } = null!;
}
