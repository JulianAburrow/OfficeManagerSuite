namespace OfficeManagerUI.Components.Pages.People.Admin.AddressTypes;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressTypeHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async void CreateAddressType()
    {
        try
        {
            CopyDisplayModelToModel();
            await AddressTypeHandler.CreateAddressTypeAsync(AddressTypeModel);
            Snackbar.Add($"Address Type {AddressTypeModel.TypeName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/addresstypes/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {AddressTypeModel.TypeName}. Please try again.", Severity.Error);
        }
    }
}
