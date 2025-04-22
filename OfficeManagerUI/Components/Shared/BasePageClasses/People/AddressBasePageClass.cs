namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class AddressBasePageClass : BasePageClass
{
    [Inject] protected IAddressHandler AddressHandler { get; set; } = null!;

    [Inject] protected IAddressTypeHandler AddressTypeHandler { get; set; } = null!;

    [Parameter] public int AddressId { get; set; }

    [SupplyParameterFromQuery]
    [Parameter] public int PersonId { get; set; }

    protected AddressModel AddressModel { get; set; } = new();

    protected AddressDisplayModel AddressDisplayModel { get; set; } = new();

    protected List<AddressTypeModel> AddressTypes { get; set; } = new();

    protected string AddressSingular = "Address";

    protected string AddressPlural = "Addresses";

    protected BreadcrumbItem GetAddressHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(AddressPlural, "/addresses/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        AddressModel.PersonId = AddressDisplayModel.PersonId;
        AddressModel.AddressLine1 = AddressDisplayModel.AddressLine1;
        AddressModel.AddressLine2 = AddressDisplayModel.AddressLine2;
        AddressModel.City = AddressDisplayModel.City;
        AddressModel.Postcode = AddressDisplayModel.Postcode;
        AddressModel.AddressTypeId = AddressDisplayModel.AddressTypeId;
    }
    
    protected void CopyModelToDisplayModel()
    {
        AddressDisplayModel.AddressLine1 = AddressModel.AddressLine1;
        AddressDisplayModel.AddressLine2 = AddressModel.AddressLine2;
        AddressDisplayModel.City = AddressModel.City;
        AddressDisplayModel.Postcode = AddressModel.Postcode;
        AddressDisplayModel.AddressTypeId = AddressModel.AddressTypeId;
    }
}
