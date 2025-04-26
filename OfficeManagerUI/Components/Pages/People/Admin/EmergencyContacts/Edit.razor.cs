namespace OfficeManagerUI.Components.Pages.People.Admin.EmergencyContacts;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        People = await PersonHandler.GetPeopleForEmergencyContactAsync();
        EmergencyContactModel = await EmergencyContactHandler.GetEmergencyContactAsync(EmergencyContactId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Emergency Contact");
    }
    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmergencyContactHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb)
        ]);
    }

    private async Task UpdateEmergencyContact()
    {
        try
        {
            CopyDisplayModelToModel();
            await EmergencyContactHandler.UpdateEmergencyContactAsync(EmergencyContactModel);
            Snackbar.Add($"Emergency contact {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName} updated successfully", Severity.Success);
            NavigationManager.NavigateTo("/emergencycontacts/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName}. Please try again.", Severity.Error);
        }
    }
}
