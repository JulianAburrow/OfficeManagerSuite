namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class AddressTypeModel
{
    public int AddressTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public ICollection<AddressModel> Addresses { get; set; } = [];
}
