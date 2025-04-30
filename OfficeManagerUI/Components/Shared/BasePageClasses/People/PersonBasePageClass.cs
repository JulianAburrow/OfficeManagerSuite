namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class PersonBasePageClass : BasePageClass
{
    [Inject] protected IPersonHandler PersonHandler { get; set; } = null!;

    [Inject] protected IEmploymentStatusHandler EmploymentStatusHandler { get; set; } = null!;

    [Inject] protected IPersonalPronounsHandler PersonalPronounsHandler { get; set; } = null!;

    [Inject] protected IGenderHandler GenderHandler { get; set; } = null!;

    [Parameter] public int PersonId { get; set; }

    protected List<EmploymentStatusModel> EmploymentStatuses { get; set; } = null!;

    protected List<PersonalPronounsModel> PersonalPronouns { get; set; } = null!;

    protected List<GenderModel> Genders { get; set; } = null!;

    protected PersonModel PersonModel { get; set; } = new();

    protected PersonDisplayModel PersonDisplayModel { get; set; } = new();

    protected string PersonSingular = "Person";

    protected string PersonPlural = "People";

    protected BreadcrumbItem GetPersonHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(PersonPlural, "/people/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        PersonModel.FirstName = PersonDisplayModel.FirstName;
        PersonModel.MiddleNames = PersonDisplayModel.MiddleNames;
        PersonModel.LastName = PersonDisplayModel.LastName;
        PersonModel.EmailAddress = PersonDisplayModel.EmailAddress;
        PersonModel.PhoneNumber = PersonDisplayModel.PhoneNumber;
        PersonModel.PersonalPronounsId = PersonDisplayModel.PersonalPronounsId == NotStatedValue
            ? null
            : PersonDisplayModel.PersonalPronounsId;
        PersonModel.GenderId = PersonDisplayModel.GenderId == NotStatedValue
            ? null
            : PersonDisplayModel.GenderId;
        PersonModel.EmploymentStatusId = PersonDisplayModel.EmploymentStatusId;
        PersonModel.Photo = PersonDisplayModel.Photo;
        PersonModel.Pronunciation = PersonDisplayModel.Pronunciation;
    }

    protected void CopyModelToDisplayModel()
    {
        PersonDisplayModel.FirstName = PersonModel.FirstName;
        PersonDisplayModel.MiddleNames = PersonModel.MiddleNames;
        PersonDisplayModel.LastName = PersonModel.LastName;
        PersonDisplayModel.EmailAddress = PersonModel.EmailAddress;
        PersonDisplayModel.PhoneNumber = PersonModel.PhoneNumber;
        PersonDisplayModel.PersonalPronounsId = PersonModel.PersonalPronounsId == null
            ? NotStatedValue
            : PersonModel.PersonalPronounsId;
        PersonDisplayModel.GenderId = PersonModel.GenderId == null
            ? NotStatedValue
            : PersonModel.GenderId;
        PersonDisplayModel.EmploymentStatusId = PersonModel.EmploymentStatusId;
        PersonDisplayModel.Photo = PersonModel.Photo;
        PersonDisplayModel.Pronunciation = PersonModel.Pronunciation;
    }

    protected override async Task OnInitializedAsync()
    {
        EmploymentStatuses = await EmploymentStatusHandler.GetEmploymentStatusesAsync();
        Genders = await GenderHandler.GetGendersAsync();
        PersonalPronouns = await PersonalPronounsHandler.GetPersonalPronounsAsync();

        EmploymentStatuses.Insert(0, new EmploymentStatusModel
        {
            EmploymentStatusId = PleaseSelectValue,
            StatusName = PleaseSelectText,
        });

       AddGenderNotStated();
        Genders.Insert(0, new GenderModel
        {
            GenderId = PleaseSelectValue,
            GenderName = PleaseSelectText,
        });

        AddPersonalPronounsNotStated();
        PersonalPronouns.Insert(0, new PersonalPronounsModel
        {
            PersonalPronounsId = PleaseSelectValue,
            PronounNames = PleaseSelectText,
        });
    }

    protected void AddGenderNotStated()
    {
        Genders.Insert(0, new GenderModel
        {
            GenderId = NotStatedValue,
            GenderName = NotStatedText,
        });
    }

    protected void AddPersonalPronounsNotStated()
    {
        PersonalPronouns.Insert(0, new PersonalPronounsModel
        {
            PersonalPronounsId = NotStatedValue,
            PronounNames = NotStatedText,
        });
    }
}
