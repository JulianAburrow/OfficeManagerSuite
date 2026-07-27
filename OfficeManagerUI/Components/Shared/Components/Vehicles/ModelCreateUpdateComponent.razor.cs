namespace OfficeManagerUI.Components.Shared.Components.Vehicles;

public partial class ModelCreateUpdateComponent
{
    [Parameter] public ModelDisplayModel ModelDisplayModel { get; set; } = null!;

    [Parameter] public List<ManufacturerModel> Manufacturers { get; set; } = null!;
}