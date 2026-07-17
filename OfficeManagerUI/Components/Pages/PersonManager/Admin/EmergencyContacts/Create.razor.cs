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
        EmergencyContactDisplayModel.PersonId = PersonId != 0 ? PersonId : PleaseSelectValue;
        EmergencyContactDisplayModel.RelationshipId = PleaseSelectValue;
        Relationships = await RelationshipHandler.GetAllRelationshipsAsync();
        Relationships.Insert(0,
            new RelationshipModel
            {
                RelationshipId = PleaseSelectValue,
                RelationshipName = PleaseSelectText,
            });
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
            NavigationManager.NavigateTo($"/personmanager/emergencycontacts/index/{EmergencyContactModel.PersonId}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating Emergency Contact {EmergencyContactModel.FirstName} {EmergencyContactModel.LastName}. Please try again.", Severity.Error);
        }
    }
}
