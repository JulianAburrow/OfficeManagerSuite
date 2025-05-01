namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmploymentStatuses;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        EmploymentStatusModel = await EmploymentStatusHandler.GetEmploymentStatusByIdAsync(EmploymentStatusId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Employment Status");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmploymentStatusHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateEmploymentStatus()
    {
        try
        {
            CopyDisplayModelToModel();
            await EmploymentStatusHandler.UpdateEmploymentStatusAsync(EmploymentStatusModel);
            Snackbar.Add($"Employment Status {EmploymentStatusModel.StatusName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/employmentstatuses/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {EmploymentStatusModel.StatusName}. Please try again.", Severity.Error);
        }
    }
}
