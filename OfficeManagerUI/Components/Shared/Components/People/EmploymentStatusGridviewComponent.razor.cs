namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class EmploymentStatusGridviewComponent
{
    [Parameter] public List<EmploymentStatusModel> EmploymentStatuses { get; set; } = new();
}
