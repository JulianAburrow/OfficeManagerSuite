namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Addresses;

public partial class View
{
    [Inject] IJSRuntime JS { get; set; } = null!;
    
    private bool ShowMap;

    protected override async Task OnInitializedAsync()
    {
        AddressModel = await AddressHandler.GetAddressByIdAsync(AddressId);
        MainLayout.SetHeaderValue("View Address");
        if (AddressModel.Latitude is not null && AddressModel.Longitude is not null)
        {
            ShowMap = true;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender || !ShowMap)
        {
            return;
        }
        
        var address = $"{AddressModel.AddressLine1} {AddressModel.AddressLine2} {AddressModel.City} {AddressModel.Postcode}";

        var locations = new List<object>
        {
            new { lat = AddressModel.Latitude, lng = AddressModel.Longitude, popup = address }
        };

        await JS.InvokeVoidAsync("showLeafletMap", "map", locations);        
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