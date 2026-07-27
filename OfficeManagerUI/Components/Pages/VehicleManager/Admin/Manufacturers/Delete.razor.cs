namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Manufacturers;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerModel = await ManufacturerHandler.GetManufacturerByIdAsync(ManufacturerId);
        MainLayout.SetHeaderValue("Delete Manufacturer");
        OkToEditOrDelete = ManufacturerModel.Vehicles.Count == 0 && ManufacturerModel.Models.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteManufacturer()
    {
        try
        {
            await ManufacturerHandler.DeleteManufacturerAsync(ManufacturerId);
            Snackbar.Add($"Manufacturer {ManufacturerModel.ManufacturerName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/vehiclemanager/manufacturers/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {ManufacturerModel.ManufacturerName}. Please try again.", Severity.Error);
        }
    }
}
