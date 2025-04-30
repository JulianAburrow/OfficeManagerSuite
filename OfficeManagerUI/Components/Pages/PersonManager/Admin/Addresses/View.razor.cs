namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Addresses;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        AddressModel = await AddressHandler.GetAddressAsync(AddressId);
        MainLayout.SetHeaderValue("View Address");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}
