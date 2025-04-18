namespace OfficeManagerUI.Models.PersonManagerModels;

public class PersonDisplayModel
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = default!;

    public string? MiddleNames { get; set; } = null!;

    public string LastName { get; set; } = default!;

    public string? EmailAddress { get; set; } = null!;

    public string? Phone { get; set; } = null!;

    public int? PersonalPronounsId { get; set; }

    public int? GenderId { get; set; }

    public int EmploymentStatusId { get; set; }

    public byte[]? Photo { get; set; } = null!;

    public byte[]? Pronunciation { get; set; } = null!;

    public PersonalPronounsModel PersonalPronoun { get; set; } = null!;

    public EmploymentStatusModel EmploymentStatus { get; set; } = null!;

    public ICollection<AddressModel> Addresses { get; set; } = [];
}
