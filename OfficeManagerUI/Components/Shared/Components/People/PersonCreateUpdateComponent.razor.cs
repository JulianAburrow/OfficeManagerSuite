namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class PersonCreateUpdateComponent
{
    [Parameter] public PersonDisplayModel PersonDisplayModel { get; set; } = null!;

    [Parameter] public List<EmploymentStatusModel> EmploymentStatuses { get; set; } = null!;

    [Parameter] public List<PersonalPronounsModel> PersonalPronouns { get; set; } = null!;

    [Parameter] public List<GenderModel> Genders { get; set; } = null!;
}
