namespace OfficeManagerUI.Components.Pages.People.Admin.Addresses;

public partial class Index
{
    private List<AddressModel> Addresses = null!;

    protected override async Task OnInitializedAsync()
    {
        var person = await PersonHandler.GetPersonAsync(PersonId);
        Addresses = await AddressHandler.GetAddressesAsync(PersonId);
        Snackbar.Add($"{Addresses.Count} item(s) found.", Addresses.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue($"{AddressPlural} for {person.FirstName} {person.LastName}");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetAddressHomeBreadcrumbItem(true),
        ]);
    }
}
