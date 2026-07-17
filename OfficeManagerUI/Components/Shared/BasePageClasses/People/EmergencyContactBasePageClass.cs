namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class EmergencyContactBasePageClass : BasePageClass
{
    [Inject] protected IEmergencyContactHandler EmergencyContactHandler { get; set; } = null!;

    [Inject] protected IRelationshipHandler RelationshipHandler { get; set; } = null!;

    [Inject] protected IPersonHandler PersonHandler { get; set; } = null!;

    [Parameter] public int EmergencyContactId { get; set; }

    [Parameter] public int PersonId { get; set; }

    protected EmergencyContactModel EmergencyContactModel { get; set; } = new();

    protected EmergencyContactDisplayModel EmergencyContactDisplayModel { get; set; } = new();

    protected List<PersonModel> People { get; set; } = [];

    protected List<RelationshipModel> Relationships { get; set; } = [];

    protected string EmergencyContactSingular = "Emergency Contact";

    protected string EmergencyContactPlural = "Emergency Contacts";

    protected BreadcrumbItem GetEmergencyContactHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new(EmergencyContactPlural, "/personmanager/emergencycontacts/index/0", isDisabled);
    }

    protected void CopyDisplayModelToModel()
    {
        EmergencyContactModel.PersonId = EmergencyContactDisplayModel.PersonId;
        EmergencyContactModel.FirstName = EmergencyContactDisplayModel.FirstName;
        EmergencyContactModel.LastName = EmergencyContactDisplayModel.LastName;
        EmergencyContactModel.RelationshipId = EmergencyContactDisplayModel.RelationshipId;
        EmergencyContactModel.PhoneNumber = EmergencyContactDisplayModel.PhoneNumber;
    }

    protected void CopyModelToDisplayModel()
    {
        EmergencyContactDisplayModel.PersonId = EmergencyContactModel.PersonId;
        EmergencyContactDisplayModel.FirstName = EmergencyContactModel.FirstName;
        EmergencyContactDisplayModel.LastName = EmergencyContactModel.LastName;
        EmergencyContactDisplayModel.RelationshipId = EmergencyContactModel.RelationshipId;
        EmergencyContactDisplayModel.PhoneNumber = EmergencyContactModel.PhoneNumber;
        EmergencyContactDisplayModel.StaffMemberName = $"{EmergencyContactModel.Person.FirstName} {EmergencyContactModel.Person.LastName}";
    }
}
