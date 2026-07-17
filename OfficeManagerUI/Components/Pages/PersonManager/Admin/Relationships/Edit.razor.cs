namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Relationships;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        RelationshipModel = await RelationshipHandler.GetRelationshipByIdAsync(RelationshipId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Relationship");
        OkToEditOrDelete = RelationshipModel.EmergencyContacts.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetRelationshipHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateRelationship()
    {
        try
        {
            CopyDisplayModelToModel();
            await RelationshipHandler.UpdateRelationshipAsync(RelationshipModel);
            Snackbar.Add($"Relationship {RelationshipModel.RelationshipName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/personmanager/relationships/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {RelationshipModel.RelationshipName}. Please try again.", Severity.Error);
        }
    }
}