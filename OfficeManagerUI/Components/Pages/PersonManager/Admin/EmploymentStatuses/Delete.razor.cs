namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmploymentStatuses;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        EmploymentStatusModel = await EmploymentStatusHandler.GetEmploymentStatusAsync(EmploymentStatusId);
        MainLayout.SetHeaderValue("Delete Employment Status");
        OkToDelete = EmploymentStatusModel.Persons != null && EmploymentStatusModel.Persons.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmploymentStatusHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteEmploymentStatus()
    {
        try
        {
            await EmploymentStatusHandler.DeleteEmploymentStatusAsync(EmploymentStatusId);
            Snackbar.Add($"Employment Status {EmploymentStatusModel.StatusName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/employmentstatuses/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {EmploymentStatusModel.StatusName}. Please try again.", Severity.Error);
        }
    }
}