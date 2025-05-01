namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class AddressGridviewComponent
{
    [Parameter] public List<AddressModel> Addresses { get; set; } = null!;

    [Parameter] public bool ShowAllColumns { get; set; } = false;
}
