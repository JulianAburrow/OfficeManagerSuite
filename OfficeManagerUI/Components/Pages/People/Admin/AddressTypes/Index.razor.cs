﻿namespace OfficeManagerUI.Components.Pages.People.Admin.AddressTypes;

public partial class Index
{
    private List<AddressTypeModel> AddressTypes = null!;

    protected override async Task OnInitializedAsync()
    {
        AddressTypes = await AddressTypeHandler.GetAddressTypesAsync();
        Snackbar.Add($"{AddressTypes.Count} item(s) found.", AddressTypes.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(AddressTypePlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressTypeHomeBreadcrumbItem(true),
        ]);
    }
}
