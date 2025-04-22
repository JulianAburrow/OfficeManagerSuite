namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class AddressCreateUpdateComponent
{
    [Parameter] public AddressDisplayModel AddressDisplayModel { get; set; } = null!;

    [Parameter] public List<AddressTypeModel> AddressTypes { get; set; } = null!;
}
