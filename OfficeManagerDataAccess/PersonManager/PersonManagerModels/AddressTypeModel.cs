namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class AddressTypeModel
{
    public int AddressTypeId { get; set; }

    public string TypeName { get; set; } = default!;

    public ICollection<AddressModel>? Addresses { get; set; } = null!;
}
