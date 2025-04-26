namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class PersonModel
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = default!;

    public string? MiddleNames { get; set; } = null!;

    public string LastName { get; set; } = default!;

    public string? EmailAddress { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;

    public int? PersonalPronounsId { get; set; }

    public int? GenderId { get; set; }

    public int EmploymentStatusId { get; set; }

    public byte[]? Photo { get; set; } = null!;

    public byte[]? Pronunciation { get; set; } = null!;

    public PersonalPronounsModel? PersonalPronouns { get; set; } = null!;

    public EmploymentStatusModel EmploymentStatus { get; set; } = default!;

    public GenderModel? Gender { get; set; } = null!;

    public ICollection<AddressModel>? Addresses { get; set; } = null!;

    public ICollection<EmergencyContactModel>? EmergencyContacts { get; set; } = null!;
}
