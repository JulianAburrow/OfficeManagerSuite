namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Models;

public partial class Create
{
    private List<ManufacturerModel> Manufacturers { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Manufacturers = await ManufacturerHandler.GetAllManufacturersAsync();
        Manufacturers.Insert(0, new ManufacturerModel
        {
            ManufacturerName = PleaseSelectText,
            ManufacturerId = PleaseSelectValue,
        });
        ModelDisplayModel.ManufacturerId = PleaseSelectValue;
        MainLayout.SetHeaderValue("Create Model");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetModelHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async Task CreateModel()
    {
        try
        {
            CopyDisplayModelToModel();
            await ModelHandler.CreateModelAsync(ModelModel);
            Snackbar.Add($"Model {ModelModel.ModelName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/vehiclemanager/models/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {ModelModel.ModelName}. Please try again.", Severity.Error);
        }
    }
}
