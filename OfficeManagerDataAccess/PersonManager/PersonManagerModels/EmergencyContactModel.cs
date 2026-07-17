namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class EmergencyContactModel
{
    public int EmergencyContactId { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public int PersonId { get; set; }

    public PersonModel Person { get; set; } = null!;

    public int RelationshipId { get; set; }

    public RelationshipModel Relationship {  get; set; } = null!;
}
