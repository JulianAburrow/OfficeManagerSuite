namespace OfficeManagerUI.Models.PersonManagerModels;

public class AddressTypeDisplayModel
{
    public int AddressTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public ICollection<AddressDisplayModel> Addresses { get; set; } = [];
}
