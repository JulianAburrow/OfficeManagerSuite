namespace OfficeManagerUI.Components.Pages.People.Admin.AddressTypes;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        AddressTypeModel = await AddressTypeHandler.GetAddressTypeAsync(AddressTypeId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Address Type");
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
            NavigationManager.NavigateTo("/addresstypes/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {AddressTypeModel.TypeName}. Please try again.", Severity.Error);
        }
    }
}
