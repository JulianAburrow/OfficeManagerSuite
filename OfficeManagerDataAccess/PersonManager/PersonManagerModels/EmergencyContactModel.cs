namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class EmergencyContactModel
{
    public int EmergencyContactId { get; set; }

    public int PersonId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string? Relationship { get; set; } = string.Empty;

    public PersonModel Person { get; set; } = null!;
}
