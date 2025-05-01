namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Addresses;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        AddressTypes = await AddressTypeHandler.GetAllAddressTypesAsync();
        AddressModel = await AddressHandler.GetAddressByIdAsync(AddressId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Address");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateAddress()
    {
        try
        {
            CopyDisplayModelToModel();
            await AddressHandler.UpdateAddressAsync(AddressModel);
            Snackbar.Add($"Address {AddressModel.AddressLine1} successfully updated", Severity.Success);
            NavigationManager.NavigateTo($"/addresses/index/{AddressModel.PersonId}");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {AddressModel.AddressLine1}. Please try again.", Severity.Error);
        }
    }
}