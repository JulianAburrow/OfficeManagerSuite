namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class PersonGridviewComponent
{
    [Inject] IJSRuntime JS { get; set; } = null!;

    [Parameter] public List<PersonModel> People { get; set; } = null!;

    private bool ShowMap;

    protected override Task OnInitializedAsync()
    {
        ShowMap = People
            .SelectMany(p => p.Addresses)
            .Any(a => a.Latitude is not null && a.Longitude is not null);

        return Task.CompletedTask;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        var locations = new List<object>();

        foreach (var person in People)
        {
            foreach (var address in person.Addresses)
            {
                if (address.Latitude is null || address.Longitude is null)
                {
                    continue;
                }
                var addressToRender = $"{person.FirstName} {person.LastName} {address.AddressType.TypeName}: {address.AddressLine1}, {address.AddressLine2}, {address.City}, {address.Postcode}";
                locations.Add(new
                {
                    lat = address.Latitude, lng = address.Longitude, popup = addressToRender
                });
            }
            
        }

        if (locations.Count > 0)
        {
            await JS.InvokeVoidAsync("showLeafletMap", "map", locations);
            ShowMap = true;
        }
    }
}
