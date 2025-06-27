namespace OfficeManagerUI.Components.Pages.VehicleManager.Admin.Colours;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Colour");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetColourHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async void CreateColour()
    {
        try
        {
            CopyDisplayModelToModel();
            await ColourHandler.CreateColourAsync(ColourModel);
            Snackbar.Add($"Colour {ColourModel.ColourName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/colours/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {ColourModel.ColourName}. Please try again.", Severity.Error);
        }
    }
}
