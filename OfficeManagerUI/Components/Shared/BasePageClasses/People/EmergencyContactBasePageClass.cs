namespace OfficeManagerUI.Components.Shared.BasePageClasses.People;

public class EmergencyContactBasePageClass : BasePageClass
{
    [Inject] protected IEmergencyContactHandler EmergencyContactHandler { get; set; } = null!;

    [Inject] protected IPersonHandler PersonHandler { get; set; } = null!;

    [Parameter] public int EmergencyContactId { get; set; }

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
        EmergencyContactModel.FirstName = EmergencyContactDisplayModel.FirstName;
        EmergencyContactModel.LastName = EmergencyContactDisplayModel.LastName;
        EmergencyContactModel.Relationship = EmergencyContactDisplayModel.Relationship;
        EmergencyContactModel.Phone = EmergencyContactDisplayModel.Phone;
    }

    protected void CopyModelToDisplayModel()
    {
        EmergencyContactDisplayModel.FirstName = EmergencyContactModel.FirstName;
        EmergencyContactDisplayModel.LastName = EmergencyContactModel.LastName;
        EmergencyContactDisplayModel.Relationship = EmergencyContactModel.Relationship;
        EmergencyContactDisplayModel.Phone = EmergencyContactModel.Phone;
    }
}
