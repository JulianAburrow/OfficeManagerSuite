﻿namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmergencyContacts;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        EmergencyContactModel = await EmergencyContactHandler.GetEmergencyContactByIdAsync(EmergencyContactId);
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
