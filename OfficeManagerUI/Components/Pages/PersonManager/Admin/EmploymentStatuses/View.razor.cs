namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmploymentStatuses;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        EmploymentStatusModel = await EmploymentStatusHandler.GetEmploymentStatusAsync(EmploymentStatusId);
        MainLayout.SetHeaderValue("View Employment Status");
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