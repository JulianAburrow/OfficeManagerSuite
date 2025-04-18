namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class EmergencyContactModel
{
    public int EmergencyContactId { get; set; }

    public int PersonId { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public string? Relationship { get; set; } = default!;

    public PersonModel Person { get; set; } = null!;
}
