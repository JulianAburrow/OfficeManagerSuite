namespace OfficeManagerDataAccess.PersonManager.PersonManagerModels;

public class EmploymentStatusModel
{
    public int EmploymentStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public ICollection<PersonModel> Persons { get; set; } = [];
}
