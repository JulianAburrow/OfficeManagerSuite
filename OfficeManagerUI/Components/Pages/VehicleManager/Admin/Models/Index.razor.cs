namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Models;

public partial class Index
{
    private List<ModelModel> Models = null!;

    protected override async Task OnInitializedAsync()
    {
        Models = await ModelHandler.GetAllModelsAsync();
        Snackbar.Add($"{Models.Count} item(s) found.", Models.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(ModelPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetModelHomeBreadcrumbItem(true),
        ]);
    }
}