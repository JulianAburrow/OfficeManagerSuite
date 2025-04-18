namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class PersonalPronounsBasePageClass : BasePageClass
{
    [Inject] protected IPersonalPronounsHandler PersonalPronounsHandler { get; set; } = null!;

    [Parameter] public int PersonalPronounsId { get; set; }

    protected PersonalPronounsModel PersonalPronounsModel { get; set; } = new();

    protected PersonalPronounsDisplayModel PersonalPronounsDisplayModel { get; set; } = new();

    protected string PersonalPronounsSingular = "Personal Pronouns";

    protected string PersonalPronounsPlural = "Personal Pronouns";

    protected BreadcrumbItem GetPersonalPronounsHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(PersonalPronounsPlural, "/personalpronouns/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        PersonalPronounsModel.PronounNames = PersonalPronounsDisplayModel.PronounNames;
    }

    protected void CopyModelToDisplayModel()
    {
        PersonalPronounsDisplayModel.PronounNames = PersonalPronounsModel.PronounNames;
    }


}