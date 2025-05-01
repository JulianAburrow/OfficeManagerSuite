namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmergencyContacts;

public partial class Index
{
    protected List<EmergencyContactModel> EmergencyContacts = null!;

    protected override async Task OnInitializedAsync()
    {
        var headerText = string.Empty;
        if (PersonId == 0)
        {
            EmergencyContacts = await EmergencyContactHandler.GetAllEmergencyContactsAsync();
            headerText = $"All {EmergencyContactPlural}";
        }
        else
        {
            EmergencyContacts = await EmergencyContactHandler.GetAllEmergencyContactsByPersonIdAsync(PersonId);
            var person = await PersonHandler.GetPersonByIdAsync(PersonId);
            headerText = $"{EmergencyContactPlural} for {person.FirstName} {person.LastName}";
        }
        Snackbar.Add($"{EmergencyContacts.Count} item(s) found.", EmergencyContacts.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(headerText);
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
