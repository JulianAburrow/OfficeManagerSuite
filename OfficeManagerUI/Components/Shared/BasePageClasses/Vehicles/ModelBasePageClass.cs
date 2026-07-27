namespace OfficeManagerUI.Components.Shared.BasePageClasses.Vehicles;

public class ModelBasePageClass : BasePageClass
{
    [Inject] protected IModelHandler ModelHandler { get; set; } = null!;

    [Inject] protected IManufacturerHandler ManufacturerHandler { get; set; } = null!;

    [Parameter] public int ModelId { get; set; }

    protected ModelModel ModelModel { get; set; } = new();

    protected ModelDisplayModel ModelDisplayModel { get; set; } = new();

    protected string ModelSingular = "Model";

    protected string ModelPlural = "Models";

    protected BreadcrumbItem GetModelHomeBreadcrumbItem(bool isDisabled =  false)
    {
        return new(ModelPlural, "/vehiclemanager/models/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        ModelModel.ModelName = ModelDisplayModel.ModelName;
        ModelModel.ManufacturerId = ModelDisplayModel.ManufacturerId;
    }

    protected void CopyModelToDisplayModel()
    {
        ModelDisplayModel.ModelName = ModelModel.ModelName;
        ModelDisplayModel.ManufacturerId = ModelModel.ManufacturerId;
    }
}
