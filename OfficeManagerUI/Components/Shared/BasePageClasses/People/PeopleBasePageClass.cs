namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class PeopleBasePageClass : BasePageClass
{
    [Inject] protected IPersonHandler PersonHandler { get; set; } = null!;

    [Inject] protected IAddressHandler AddressHandler { get; set; } = null!;

    [Inject] protected IEmploymentStatusHandler EmploymentStatusHandler { get; set; } = null!;

    [Inject] protected IPersonalPronounsHandler PersonalPronounsHandler { get; set; } = null!;

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
        PersonModel.Phone = PersonDisplayModel.Phone;
        PersonModel.PersonalPronounsId = PersonDisplayModel.PersonalPronounsId;
        PersonModel.GenderId = PersonDisplayModel.GenderId;
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
        PersonDisplayModel.Phone = PersonModel.Phone;
        PersonDisplayModel.PersonalPronounsId = PersonModel.PersonalPronounsId;
        PersonDisplayModel.GenderId = PersonModel.GenderId;
        PersonDisplayModel.EmploymentStatusId = PersonModel.EmploymentStatusId;
        PersonDisplayModel.Photo = PersonModel.Photo;
        PersonDisplayModel.Pronunciation = PersonModel.Pronunciation;
    }
}
