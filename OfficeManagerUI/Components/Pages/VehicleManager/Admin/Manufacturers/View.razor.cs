namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Manufacturers;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerModel = await ManufacturerHandler.GetManufacturerByIdAsync(ManufacturerId);
        MainLayout.SetHeaderValue("View Manufacturer");
        OkToEditOrDelete = ManufacturerModel.Vehicles.Count == 0 &&
                            ManufacturerModel.Models.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}