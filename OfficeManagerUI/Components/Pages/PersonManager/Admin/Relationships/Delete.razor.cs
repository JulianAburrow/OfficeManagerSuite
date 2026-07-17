namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Relationships;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        RelationshipModel = await RelationshipHandler.GetRelationshipByIdAsync(RelationshipId);
        MainLayout.SetHeaderValue("Delete Relationship");
        OkToEditOrDelete = RelationshipModel.EmergencyContacts != null && RelationshipModel.EmergencyContacts.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetRelationshipHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteRelationship()
    {
        try
        {
            await RelationshipHandler.DeleteRelationshipAsync(RelationshipId);
            Snackbar.Add($"Relationship {RelationshipModel.RelationshipName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/personmanager/relationships/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {RelationshipModel.RelationshipName}. Please try again.", Severity.Error);
        }
    }
}