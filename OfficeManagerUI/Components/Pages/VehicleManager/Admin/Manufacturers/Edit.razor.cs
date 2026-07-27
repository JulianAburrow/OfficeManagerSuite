namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Manufacturers;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerModel = await ManufacturerHandler.GetManufacturerByIdAsync(ManufacturerId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Manufacturer");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateManufacturer()
    {
        try
        {
            CopyDisplayModelToModel();
            await ManufacturerHandler.UpdateManufacturerAsync(ManufacturerModel);
            Snackbar.Add($"Manufacturer {ManufacturerModel.ManufacturerName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/vehiclemanager/manufacturers/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {ManufacturerModel.ManufacturerName}. Please try again.", Severity.Error);
        }
    }
}