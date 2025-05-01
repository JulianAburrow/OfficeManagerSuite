namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmergencyContacts;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        People = await PersonHandler.GetAllPeopleForEmergencyContactAsync();
        EmergencyContactModel = await EmergencyContactHandler.GetEmergencyContactByIdAsync(EmergencyContactId);
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
            NavigationManager.NavigateTo($"/emergencycontacts/index/{EmergencyContactModel.PersonId}");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName}. Please try again.", Severity.Error);
        }
    }
}
