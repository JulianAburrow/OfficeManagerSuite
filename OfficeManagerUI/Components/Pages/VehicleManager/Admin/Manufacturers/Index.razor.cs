namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Manufacturers;

public partial class Index
{
    private List<ManufacturerModel> Manufacturers = null!;

    protected override async Task OnInitializedAsync()
    {
        Manufacturers = await ManufacturerHandler.GetAllManufacturersAsync();
        Snackbar.Add($"{Manufacturers.Count} item(s) found.", Manufacturers.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(ManufacturerPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(true),
        ]);
    }
}