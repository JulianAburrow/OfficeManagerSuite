namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Colours;

public partial class Index
{
    private List<ColourModel> Colours = null!;

    protected override async Task OnInitializedAsync()
    {
        Colours = await ColourHandler.GetAllColoursAsync();
        Snackbar.Add($"{Colours.Count} item(s) found.", Colours.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(ColourPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(true),
        ]);
    }
}
