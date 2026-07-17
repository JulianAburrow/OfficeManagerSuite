namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Relationships;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        RelationshipModel = await RelationshipHandler.GetRelationshipByIdAsync(RelationshipId);
        MainLayout.SetHeaderValue("View Relationship");
        OkToEditOrDelete = RelationshipModel.EmergencyContacts is not null && !RelationshipModel.EmergencyContacts.Any();
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
                GetHomeBreadcrumbItem(),
                GetRelationshipHomeBreadcrumbItem(),
                GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}