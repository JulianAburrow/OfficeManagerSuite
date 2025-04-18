namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class AddressTypeBasePageClass : BasePageClass
{
    [Inject] protected IAddressTypeHandler AddressTypeHandler { get; set; } = null!;

    [Parameter] public int AddressTypeId { get; set; }

    protected AddressTypeModel AddressTypeModel { get; set; } = new();

    protected AddressTypeDisplayModel AddressTypeDisplayModel { get; set; } = new();

    protected string AddressTypeSingular = "Address Type";

    protected string AddressTypePlural = "Address Types";

    protected BreadcrumbItem GetAddressTypeHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(AddressTypePlural, "/addresstypes/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        AddressTypeModel.TypeName = AddressTypeDisplayModel.TypeName;
    }

    protected void CopyModelToDisplayModel()
    {
        AddressTypeDisplayModel.TypeName = AddressTypeModel.TypeName;
    }
}
