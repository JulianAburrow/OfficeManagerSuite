namespace OfficeManagerUI.Components.Pages.People.Admin.EmergencyContacts;

public partial class Create
{
    protected override async Task OnInitializedAsync()
    {
        People = await PersonHandler.GetPeopleForEmergencyContactAsync();
        MainLayout.SetHeaderValue("Create Emergency Contact");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmergencyContactHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async void CreateEmergencyContact()
    {
        try
        {
            CopyDisplayModelToModel();
            await EmergencyContactHandler.CreateEmergencyContactAsync(EmergencyContactModel);
            Snackbar.Add($"Emergency Contact {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/emergencycontacts/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating Emergency Contact {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName}. Please try again.", Severity.Error);
        }
    }
}
