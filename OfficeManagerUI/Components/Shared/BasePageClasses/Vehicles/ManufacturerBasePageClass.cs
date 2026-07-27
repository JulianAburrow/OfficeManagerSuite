namespace OfficeManagerUI.Components.Shared.BasePageClasses.Vehicles;

public class ManufacturerBasePageClass : BasePageClass
{
    [Inject] protected IManufacturerHandler ManufacturerHandler { get; set; } = null!;

    [Parameter] public int ManufacturerId { get; set; }

    protected ManufacturerModel ManufacturerModel { get; set; } = new();

    protected ManufacturerDisplayModel ManufacturerDisplayModel { get; set; } = new();

    protected string ManufacturerSingular = "Manufacturer";

    protected string ManufacturerPlural = "Manufacturers";

    protected BreadcrumbItem GetManufacturerHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(ManufacturerPlural, "/vehiclemanager/manufacturers/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        ManufacturerModel.ManufacturerName = ManufacturerDisplayModel.ManufacturerName;
    }

    protected void CopyModelToDisplayModel()
    {
        ManufacturerDisplayModel.ManufacturerName = ManufacturerModel.ManufacturerName;
    }
}
