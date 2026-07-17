namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.AddressTypes;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        AddressTypeModel = await AddressTypeHandler.GetAddressTypeByIdAsync(AddressTypeId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Address Type");
        OkToEditOrDelete = AddressTypeModel.Addresses.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressTypeHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateAddressType()
    {
        try
        {
            CopyDisplayModelToModel();
            await AddressTypeHandler.UpdateAddressTypeAsync(AddressTypeModel);
            Snackbar.Add($"Address Type {AddressTypeModel.TypeName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/personmanager/addresstypes/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {AddressTypeModel.TypeName}. Please try again.", Severity.Error);
        }
    }
}
