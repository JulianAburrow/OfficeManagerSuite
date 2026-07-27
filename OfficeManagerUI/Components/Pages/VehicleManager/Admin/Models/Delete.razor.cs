namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Models;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        ModelModel = await ModelHandler.GetModelByIdAsync(ModelId);
        MainLayout.SetHeaderValue("Delete Model");
        OkToEditOrDelete = ModelModel.Vehicles.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetModelHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteModel()
    {
        try
        {
            await ModelHandler.DeleteModelAsync(ModelId);
            Snackbar.Add($"Model {ModelModel.ModelName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/vehiclemanager/models/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {ModelModel.ModelName}. Please try again.", Severity.Error);
        }
    }
}
