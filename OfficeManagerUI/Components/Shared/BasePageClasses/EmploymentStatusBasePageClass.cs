namespace OfficeManagerUI.Components.Shared.BasePageClasses;

public class EmploymentStatusBasePageClass : BasePageClass
{
    [Inject] protected IEmploymentStatusHandler EmploymentStatusHandler { get; set; } = null!;

    [Parameter] public int EmploymentStatusId { get; set; }

    protected EmploymentStatusModel EmploymentStatusModel { get; set; } = new();

    protected EmploymentStatusDisplayModel EmploymentStatusDisplayModel { get; set; } = new();

    protected string EmploymentStatusSingular = "Employment Status";

    protected string EmploymentStatusPlural = "Employment Statuses";

    protected BreadcrumbItem GetEmploymentStatusHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new("Employment Statuses", "/employmentstatuses/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        EmploymentStatusModel.StatusName = EmploymentStatusDisplayModel.StatusName;
    }

    protected void CopyModelToDisplayModel()
    {
        EmploymentStatusDisplayModel.StatusName = EmploymentStatusModel.StatusName;
    }
}
