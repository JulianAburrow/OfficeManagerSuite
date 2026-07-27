namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Models;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ModelModel = await ModelHandler.GetModelByIdAsync(ModelId);
        MainLayout.SetHeaderValue("View Model");
        OkToEditOrDelete = ModelModel.Vehicles.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetModelHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}