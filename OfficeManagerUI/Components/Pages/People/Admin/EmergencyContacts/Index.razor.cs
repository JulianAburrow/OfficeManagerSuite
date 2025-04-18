namespace OfficeManagerUI.Components.Pages.People.Admin.EmergencyContacts;

public partial class Index
{
    protected List<EmergencyContactModel> EmergencyContacts = null!;

    protected override async Task OnInitializedAsync()
    {
        EmergencyContacts = await EmergencyContactHandler.GetEmergencyContactsAsync();
        Snackbar.Add($"{EmergencyContacts.Count} item(s) found.", EmergencyContacts.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(EmergencyContactPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmergencyContactHomeBreadcrumbItem(true),
        ]);
    }
}
