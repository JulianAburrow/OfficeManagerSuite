namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class GenderBasePageClass : BasePageClass
{
    [Inject] protected IGenderHandler GenderHandler { get; set; } = null!;

    [Parameter] public int GenderId { get; set; }

    protected GenderModel GenderModel { get; set; } = new();

    protected GenderDisplayModel GenderDisplayModel { get; set; } = new();

    protected string GenderSingular = "Gender";

    protected string GenderPlural = "Genders";

    protected BreadcrumbItem GetGenderHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(GenderPlural, "/genders/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        GenderModel.GenderName = GenderDisplayModel.GenderName;
    }

    protected void CopyModelToDisplayModel()
    {
        GenderDisplayModel.GenderName = GenderModel.GenderName;
    }
}
