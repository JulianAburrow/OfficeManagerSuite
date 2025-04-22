namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class AddressModel
{
    public int AddressId { get; set; }

    public int PersonId { get; set; }

    public string AddressLine1 { get; set; } = default!;

    public string AddressLine2 { get; set; } = null!;

    public string City { get; set; } = default!;

    public string Postcode { get; set; } = default!;

    public int AddressTypeId { get; set; }

    public PersonModel Person { get; set; } = null!;

    public AddressTypeModel AddressType { get; set; } = null!;
}
