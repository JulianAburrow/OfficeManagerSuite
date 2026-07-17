namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.AddressTypes;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        AddressTypeModel = await AddressTypeHandler.GetAddressTypeByIdAsync(AddressTypeId);
        MainLayout.SetHeaderValue("View Address Type");
        OkToEditOrDelete = AddressTypeModel.Addresses.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressTypeHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}
