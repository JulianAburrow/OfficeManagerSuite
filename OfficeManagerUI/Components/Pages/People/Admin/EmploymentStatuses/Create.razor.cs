namespace OfficeManagerUI.Components.Pages.People.Admin.EmploymentStatuses;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Employment Status");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmploymentStatusHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async void CreateEmploymentStatus()
    {
        try
        {
            CopyDisplayModelToModel();
            await EmploymentStatusHandler.CreateEmploymentStatusAsync(EmploymentStatusModel);
            Snackbar.Add($"Employment Status {EmploymentStatusModel.StatusName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/employmentstatuses/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {EmploymentStatusModel.StatusName}. Please try again.", Severity.Error);
        }
    }
}
