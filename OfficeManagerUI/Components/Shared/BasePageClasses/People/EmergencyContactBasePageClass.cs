namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class EmergencyContactBasePageClass : BasePageClass
{
    [Inject] protected IEmergencyContactHandler EmergencyContactHandler { get; set; } = null!;

    [Inject] protected IPersonHandler PersonHandler { get; set; } = null!;

    [Parameter] public int EmergencyContactId { get; set; }

    [Parameter] public int PersonId { get; set; }

    protected EmergencyContactModel EmergencyContactModel { get; set; } = new();

    protected EmergencyContactDisplayModel EmergencyContactDisplayModel { get; set; } = new();

    protected List<PersonModel> People { get; set; } = [];

    protected string EmergencyContactSingular = "Emergency Contact";

    protected string EmergencyContactPlural = "Emergency Contacts";

    protected BreadcrumbItem GetEmergencyContactHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(EmergencyContactPlural, "/emergencycontacts/index", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        EmergencyContactModel.PersonId = EmergencyContactDisplayModel.PersonId;
        EmergencyContactModel.FirstName = EmergencyContactDisplayModel.FirstName;
        EmergencyContactModel.LastName = EmergencyContactDisplayModel.LastName;
        EmergencyContactModel.Relationship = EmergencyContactDisplayModel.Relationship;
        EmergencyContactModel.PhoneNumber = EmergencyContactDisplayModel.PhoneNumber;
    }

    protected void CopyModelToDisplayModel()
    {
        EmergencyContactDisplayModel.PersonId = EmergencyContactModel.PersonId;
        EmergencyContactDisplayModel.FirstName = EmergencyContactModel.FirstName;
        EmergencyContactDisplayModel.LastName = EmergencyContactModel.LastName;
        EmergencyContactDisplayModel.Relationship = EmergencyContactModel.Relationship;
        EmergencyContactDisplayModel.PhoneNumber = EmergencyContactModel.PhoneNumber;
        EmergencyContactDisplayModel.StaffMemberName = $"{EmergencyContactModel.Person.FirstName} {EmergencyContactModel.Person.LastName}";
    }
}
