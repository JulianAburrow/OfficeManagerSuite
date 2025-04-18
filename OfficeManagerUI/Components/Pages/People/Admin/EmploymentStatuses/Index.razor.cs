namespace OfficeManagerUI.Components.Pages.People.Admin.EmploymentStatuses;

public partial class Index
{
    protected List<EmploymentStatusModel> EmploymentStatuses = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            EmploymentStatuses = await EmploymentStatusHandler.GetEmploymentStatusesAsync();
            Snackbar.Add($"{EmploymentStatuses.Count} item(s) found.", EmploymentStatuses.Count > 0 ? Severity.Info : Severity.Warning);
            MainLayout.SetHeaderValue(EmploymentStatusPlural);
        }
        catch (Exception ex)
        {
            Snackbar.Add($"An error occurred retrieving Employment Statuses: {ex.Message}", Severity.Error);
        }
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmploymentStatusHomeBreadcrumbItem(true),
        ]);
    }
}
