namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Manufacturers;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Manufacturer");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async Task CreateManufacturer()
    {
        try
        {
            CopyDisplayModelToModel();
            await ManufacturerHandler.CreateManufacturerAsync(ManufacturerModel);
            Snackbar.Add($"Manufacturer {ManufacturerModel.ManufacturerName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/vehiclemanager/manufacturers/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {ManufacturerModel.ManufacturerName}. Please try again.", Severity.Error);
        }
    }
}
