namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Addresses;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        AddressModel = await AddressHandler.GetAddressByIdAsync(AddressId);
        MainLayout.SetHeaderValue("Delete Address");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteAddress()
    {
        try
        {
            await AddressHandler.DeleteAddressAsync(AddressId);
            Snackbar.Add($"Address {AddressModel.AddressLine1} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo($"/addresses/index/{AddressModel.PersonId}");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {AddressModel.AddressLine1}. Please try again.", Severity.Error);
        }
    }
}
