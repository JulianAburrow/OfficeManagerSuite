namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmergencyContacts;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        EmergencyContactModel = await EmergencyContactHandler.GetEmergencyContactByIdAsync(EmergencyContactId);
        MainLayout.SetHeaderValue("Delete Emergency Contact");
    }
    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmergencyContactHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteEmergencyContact()
    {
        try
        {
            await EmergencyContactHandler.DeleteEmergencyContactAsync(EmergencyContactId);
            Snackbar.Add($"Emergency contact {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/emergencycontacts/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName}. Please try again.", Severity.Error);
        }
    }
}
