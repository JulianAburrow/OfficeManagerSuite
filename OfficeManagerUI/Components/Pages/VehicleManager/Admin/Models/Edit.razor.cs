namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Models;

public partial class Edit
{
    private List<ManufacturerModel> Manufacturers { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        ModelModel = await ModelHandler.GetModelByIdAsync(ModelId);
        Manufacturers = await ManufacturerHandler.GetAllManufacturersAsync();
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Model");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetModelHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateModel()
    {
        try
        {
            CopyDisplayModelToModel();
            await ModelHandler.UpdateModelAsync(ModelModel);
            Snackbar.Add($"Model {ModelModel.ModelName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/vehiclemanager/models/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {ModelModel.ModelName}. Please try again.", Severity.Error);
        }
    }
}
