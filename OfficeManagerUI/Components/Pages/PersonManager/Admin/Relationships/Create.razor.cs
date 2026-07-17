namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Relationships;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Relationship");
        MainLayout.SetBreadcrumbs(
        [
                GetHomeBreadcrumbItem(),
                GetRelationshipHomeBreadcrumbItem(),
                GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async Task CreateRelationship()
    {
        try
        {
            CopyDisplayModelToModel();
            await RelationshipHandler.CreateRelationshipAsync(RelationshipModel);
            Snackbar.Add($"Relationship {RelationshipDisplayModel.RelationshipName} successfully created", Severity.Success);
            NavigationManager.NavigateTo($"/personmanager/relationships/view");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {RelationshipDisplayModel.RelationshipName}. Please try again.", Severity.Error);
        }
    }
}