namespace OfficeManagerUI.Components.Pages.People.Admin.EmergencyContacts;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        EmergencyContactModel = await EmergencyContactHandler.GetEmergencyContactAsync(EmergencyContactId);
        MainLayout.SetHeaderValue("View Emergency Contact");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetEmergencyContactHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb)
        ]);
    }
}
