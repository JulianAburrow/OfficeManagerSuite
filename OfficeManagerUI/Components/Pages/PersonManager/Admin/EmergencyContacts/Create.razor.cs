namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.EmergencyContacts;

public partial class Create
{
    protected override async Task OnInitializedAsync()
    {
        People = await PersonHandler.GetAllPeopleForEmergencyContactAsync();
        People.Insert(0, new PersonModel {
            PersonId = PleaseSelectValue,
            FirstName = PleaseSelectText
        });
        EmergencyContactDisplayModel.PersonId = PersonId != default! ? PersonId : PleaseSelectValue;
        Relationships = await EmergencyContactHandler.GetAllRelationshipsAsync();
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
            NavigationManager.NavigateTo($"/emergencycontacts/index/{EmergencyContactModel.PersonId}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating Emergency Contact {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName}. Please try again.", Severity.Error);
        }
    }
}
