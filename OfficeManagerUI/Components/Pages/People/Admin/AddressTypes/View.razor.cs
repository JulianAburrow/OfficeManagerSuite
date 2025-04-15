namespace OfficeManagerUI.Components.Pages.People.Admin.AddressTypes;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        AddressTypeModel = await AddressTypeHandler.GetAddressTypeAsync(AddressTypeId);
        MainLayout.SetHeaderValue("View Address Type");
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
