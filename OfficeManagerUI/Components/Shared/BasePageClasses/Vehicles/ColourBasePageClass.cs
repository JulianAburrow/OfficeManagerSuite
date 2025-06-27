namespace OfficeManagerUI.Components.Shared.BasePageClasses.Vehicles;

public class ColourBasePageClass : BasePageClass
{
    [Inject] protected IColourHandler ColourHandler { get; set; } = null!;

    [Parameter] public int ColourId { get; set; }

    protected ColourModel ColourModel { get; set; } = new();

    protected ColourDisplayModel ColourDisplayModel { get; set; } = new();

    protected string ColourSingular = "Colour";

    protected string ColourPlural = "Colours";

    protected BreadcrumbItem GetColourHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(ColourPlural, "/colours/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        ColourModel.ColourName = ColourDisplayModel.ColourName;
    }

    protected void CopyModelToDisplayModel()
    {
        ColourDisplayModel.ColourName = ColourModel.ColourName;
    }
}
