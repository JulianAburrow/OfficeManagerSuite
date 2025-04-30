namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Addresses;

public partial class Create
{
    protected override async Task OnInitializedAsync()
    {
        AddressDisplayModel.PersonId = PersonId;
        AddressDisplayModel.AddressTypeId = PleaseSelectValue;
        AddressTypes = await AddressTypeHandler.GetAddressTypesAsync();
        AddressTypes.Insert(0, new AddressTypeModel
        {
            AddressTypeId = PleaseSelectValue,
            TypeName = PleaseSelectText,
        });
    }

    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Address");
        MainLayout.SetBreadcrumbs(
        [
                GetHomeBreadcrumbItem(),
                GetAddressHomeBreadcrumbItem(),
                GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async Task CreateAddress()
    {
        try
        {
            CopyDisplayModelToModel();
            await AddressHandler.CreateAddressAsync(AddressModel);
            Snackbar.Add($"Address {AddressModel.AddressLine1} successfully created", Severity.Success);
            NavigationManager.NavigateTo($"/person/view/{PersonId}");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {AddressModel.AddressLine1}. Please try again.", Severity.Error);
        }
    }
}
