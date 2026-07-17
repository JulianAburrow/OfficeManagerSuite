namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmploymentStatuses;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        EmploymentStatusModel = await EmploymentStatusHandler.GetEmploymentStatusByIdAsync(EmploymentStatusId);
        MainLayout.SetHeaderValue("View Employment Status");
        OkToEditOrDelete = EmploymentStatusModel.Persons.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmploymentStatusHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}