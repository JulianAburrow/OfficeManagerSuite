namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.AddressTypes;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        AddressTypeModel = await AddressTypeHandler.GetAddressTypeAsync(AddressTypeId);
        MainLayout.SetHeaderValue("Delete Address Type");
        OkToDelete = AddressTypeModel.Addresses != null && AddressTypeModel.Addresses.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressTypeHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteAddressType()
    {
        try
        {
            await AddressTypeHandler.DeleteAddressTypeAsync(AddressTypeId);
            Snackbar.Add($"Address Type {AddressTypeModel.TypeName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/addresstypes/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {AddressTypeModel.TypeName}. Please try again.", Severity.Error);
        }
    }
}
