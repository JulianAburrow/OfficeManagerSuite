namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Relationships;

public partial class Index
{
    private List<RelationshipModel> Relationships = null!;

    protected override async Task OnInitializedAsync()
    {
        Relationships = await RelationshipHandler.GetAllRelationshipsAsync();
        Snackbar.Add($"{Relationships.Count} item(s) found.", Relationships.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(RelationshipPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetRelationshipHomeBreadcrumbItem(true),
        ]);
    }
}